<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Mon1.Models.ENode>>" %>

<asp:content ID="Content2" contentplaceholderid="MainContent" runat="server">
  <%   
      Html.Telerik()
          .Grid<Mon1.Models.ENode>(Model)
          .Name("Grid")
          .DataKeys(keys => keys.Add(c => c.id).RouteKey("id"))
          .DataBinding(b =>
              {
                  b.Server().Select("EditorInGrid", "Editor");
                  b.Server().Update("UpdateNode", "Editor");
              })
          .Columns(col =>
          {
#if true
              col.Bound(c => c.composite).Title("Data").Width(200).Encoded(false);
              //            col.Bound(c => c.ip).Title("IP Address").Width(100);
              //            col.Bound(c => c.devicetype).Title("Device Type");
              //            col.Bound(c => c.macaddress).Title("MacAddress");
              col.Bound(c => c.notes).Title("Notifications(Notes)").Encoded(false);
              col.Command(cmd => cmd.Edit()).Width(200);
#else
            col.Bound(c => c.mname).Title("Name").Width(200).ReadOnly();
            col.Bound(c => c.ip).Title("IP Address").Width(100).ReadOnly();
            col.Bound(c => c.devicetype).Title("Device Type").Width(100).ReadOnly();
            col.Bound(c => c.macaddress).Title("MacAddress").Width(100).ReadOnly();
            col.Bound(c => c.notes).Title("Notifications(Notes)").Width(250).Encoded(false);
            col.Command(cmd => cmd.Edit()).Width(90);
#endif
          })
          .Pageable(p =>
          {
              p.PageSize(10);
              p.Position(GridPagerPosition.Both);
              p.Style(GridPagerStyles.NextPrevious);
          })
          .Scrollable(b =>
              {
                  b.Height(800);
                  b.Enabled(true);
              })
          .Sortable()
          .Filterable()
          //.Resizable(r => r.Columns(true))
          .Render();
        %>
</asp:content>