using System;
using System.Linq.Expressions;
using Gtk;
using System.Reflection;
using Pony.Validation;
using System.Linq;
using System.Collections.Generic;

namespace Pony.GtkSharp
{
	public class ViewDialog<T> : Gtk.Dialog where T : class, new()
	{
        protected readonly GtkErrorProvider _errorProvider;

		private readonly IPonyApplication _ponyApplication;

		public T Model { get; private set; }

		protected delegate void BindingEvent();

		protected event BindingEvent ModelChanged;

		public ViewDialog (IPonyApplication ponyApplication)
		{
			_ponyApplication = ponyApplication;
            _errorProvider = new GtkErrorProvider(this);
            DeleteEvent += (o, args) => { if (Model == null) Model = new T (); };
            DestroyEvent += (o, args) => { if (Model == null) Model = new T (); };
            Response += (o, args) => { if (Model == null) Model = new T (); };
		}

		public void SetModel(T model)
		{
			Model = model;
			if (ModelChanged != null) ModelChanged();
		}

		public new void Show()
		{
            //This is required for instantiation of ViewDialog without showing it.
		}

        protected void Bind<TBind, TControl, TView>(
            Expression<Func<T, TBind>> modelPropertyExpr,
            Expression<Func<TView, TControl>> formPropertyExpr)
            where TView : ViewDialog<T>
            where TControl : Entry
        {
            var modelMember = (MemberExpression)modelPropertyExpr.Body;
            var modelProperty = (PropertyInfo)modelMember.Member;

            var formMember = (MemberExpression)formPropertyExpr.Body;
            var formProperty = (FieldInfo)formMember.Member;
            var control = (Entry)formProperty.GetValue(this);

            var propertyValidationAttributes =
                modelProperty.GetCustomAttributes<PropertyValidationAttribute>(true).ToList();
            var serializer = _ponyApplication.GetSerializer<TBind>();

            ModelChanged += () => control.Text = _ponyApplication.GetSerializer<TBind>().Serialize((TBind)modelProperty.GetValue(Model));

            control.FocusOutEvent += (o, args) => {
                var error = control.Validate(serializer, propertyValidationAttributes);
                if (string.IsNullOrEmpty(error))
                    _errorProvider.ReleaseError(control);
                else
                {
                    _errorProvider.SetError(control, error);
                    ShowError(modelProperty.Name, error);
                }
            };
          
            Response += (o, args) =>
                {
                    if (ResponseTypeRegistry.PositiveResponseTypes.Contains(args.ResponseId))
                    {
                        modelProperty.SetValue(Model, serializer.Deserialize(control.Text));
                    }
                };
        }

        protected void Bind<TControl, TView>(
            Expression<Func<T, bool>> modelPropertyExpr,
            Expression<Func<TView, TControl>> formPropertyExpr)
            where TView : ViewDialog<T>
            where TControl : CheckButton
        {
            var modelMember = (MemberExpression)modelPropertyExpr.Body;
            var modelProperty = (PropertyInfo)modelMember.Member;

            var formMember = (MemberExpression)formPropertyExpr.Body;
            var formProperty = (FieldInfo)formMember.Member;
            var control = (CheckButton)formProperty.GetValue(this);

            ModelChanged += () => control.Active = (bool)modelProperty.GetValue(Model);

            Response += (o, args) =>
            {
                if (args.ResponseId == ResponseType.Ok || args.ResponseId == ResponseType.Accept)
                {
                        modelProperty.SetValue(Model, control.Active);
                }
            };
        }

        protected void ShowError(string propertyName, string error)
        {
            var md = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, error);
            md.Title = propertyName;
            md.Run();
            md.Destroy();
        }
            
        public override void Dispose()
        {
            if (this != null)
            {
                Destroy();
                base.Dispose();
            }
        }
	}
}

