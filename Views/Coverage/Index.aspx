<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Mon1.Models.asa>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

       <h2>Mid-Range Monitoring Coverage</h2>
      <%= Html.Telerik().Grid<Mon1.Models.asa>(Model)
        .Name("Grid")
        .DataKeys(keys => keys.Add(c => c.id))
          .ToolBar(commands => commands
              .Custom()
              .HtmlAttributes(new { id = "export" })
              .Text("Export to CSV")
              // Until we figure out current values for orderBy & filter
              //  this will export the ENTIRE grid
              //.Action("ExportCsv", "FlatFile", new { page = 1, orderBy = "~", filter = "~" }))
              .Action("ExportCsv", "FlatFile", new { page = 1 }))
        .DataBinding(dataBinding => dataBinding.Server().Select("Index","Coverage") )
        .Columns(col =>
        {
            col.Bound(c => c.businessowner).Title("Owner");
            col.Bound(c => c.nodetype).Title("NodeType");
            col.Bound(c => c.framename).Title("Frame");
            col.Bound(c => c.servername).Title("Server").Width(150);
            col.Bound(c => c.environment).Title("Environment").Width(80);
            col.Bound(c => c.os).Title("OS");
            col.Bound(c => c.ismonitored).Title("IsMonitored?").Width(100);
            col.Bound(c => c.toolname).Title("Tool");
           // col.Bound(c => c.whyunmonitored).Title("WhyUnmonitored").Width(80);
            col.Bound(c => c.lastupdated).Title("AsOf").Format("{0:MM/dd/yy}");
            
            //  these are extra columns as specified in AMKT's original Excel file.
            //col.Bound(c => c.datacenter).Title("Data Center").Width(150);
            //col.Bound(c => c.hardwaremodel).Title("Hardware").Width(150);
            //col.Bound(c => c.serialnumber).Title("SerialNumber").Width(200);
          //  col.Bound(c => c.servereol).Title("Server EOL").Width(200);
        })
        // blows out the widths ?? .Resizable(r=>r.Columns(true))
        .Pageable(p => 
        {
            p.PageSize(100);
            p.Position(GridPagerPosition.Both);
            p.Style(GridPagerStyles.NextPrevious);
        })     
        .Scrollable(b =>
              {
                  b.Height(800);
                  b.Enabled(true);
              })
        //.Scrollable()
        .Groupable()
        .Sortable()
        .Filterable()
        %>


</asp:Content>
