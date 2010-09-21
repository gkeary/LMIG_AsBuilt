<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Mon1.Models.EditableNode>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <%   
    Html.Telerik().Grid(Model)
        .Name("Grid")
        .DataKeys(keys => keys.Add(c => c.id))
        .DataBinding(b=>
            {
                b.Server().Select("EditorInGrid","Notes");
                b.Server().Update("UpdXXteNode","Notes");
            })
        .Columns(col =>
        {
            col.Bound(c => c.mname).Title("Name").ReadOnly();
            col.Bound(c => c.ip).Title("IP Address").ReadOnly();
            col.Bound(c => c.devicetype).Title("Device Type").ReadOnly();
            col.Bound(c => c.macaddress).Title("MacAddress").ReadOnly();
            col.Bound(c => c.notes).Title("Notifications(Notes)").Encoded(false);
            col.Command(cmd => cmd.Edit());
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
        .Resizable(r=>r.Columns(true))
        .Render();
        %>

</asp:Content>
