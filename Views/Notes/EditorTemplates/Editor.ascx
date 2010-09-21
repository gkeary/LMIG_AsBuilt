<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
  <%= Html.Telerik().Editor()
      .Tools(t=>
          {
              t.Clear();
              t.Separator();
          })
      .Name(ViewData.TemplateInfo.GetFullHtmlFieldName(string.Empty))
      .Value(Model)
    %>
