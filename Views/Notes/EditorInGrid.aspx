<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Mon1.Models.EditableNode>>" %>

<asp:content ID="Content2" contentplaceholderid="MainContent" runat="server">
  <%   
    Html.Telerik()
        .Grid<Mon1.Models.EditableNode>(Model)
        .Name("Grid")
        //.DataKeys(keys => keys.Add(e => e.EmployeeID).RouteKey("Id"))
        .DataKeys(keys => keys.Add(c => c.id).RouteKey("id"))
        .DataBinding(b =>
            {
                b.Server().Select("EditorInGrid", "Notes");
                b.Server().Update("UpdateNode", "Notes");
            })
        .Columns(col =>
        {
#if true
            col.Bound(c => c.mname).Title("Name").ReadOnly();
            col.Bound(c => c.ip).Title("IP Address").ReadOnly();
            col.Bound(c => c.devicetype).Title("Device Type").ReadOnly();
            col.Bound(c => c.macaddress).Title("MacAddress").ReadOnly();
            col.Bound(c => c.notes).Title("Notifications(Notes)").Encoded(false);
            col.Command(cmd => cmd.Edit());
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
            p.PageSize(25);
            p.Position(GridPagerPosition.Both);
            p.Style(GridPagerStyles.NextPrevious);
        })
        .Scrollable()
        .Sortable()
        .Filterable()
        .Resizable(r => r.Columns(true))
        .Render();
        %>
</asp:content>