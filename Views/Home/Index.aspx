<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        Html.Telerik().TabStrip()
            .Name("TabStrip")
            .Items(parent =>
            {
                parent.Add().Text("Quick Links")
                   .Content(() =>
                   {%>
    <h2> Quick Links</h2>
    <div>
        <ul>
            <li> <%= Html.ActionLink("Edit Notes", "EditorInGrid", "Editor")%></li>
            <li> <%= Html.ActionLink("Coverage Report", "Index", "Coverage")%></li>
        </ul>
    </div>
    <br />
    <br />
    <br />
    <div>
        <h5> Version: 1.2 </h5>
        <h5> Dated : 9/2/2010</h5>
        <h5> Author: Gregg Keary </h5>
    </div>
    <%})
                  .Selected(true);
        parent.Add()
            .Text("Spectrum Help")
            .Content(() =>
            {%>
    <h2>Hints for the Notes Grid</h2>
    
    <table border="11px">
    <tr>
    <td><b>Description</b></td>
    <td>    This page permits viewing and editing Spectrum Notes entries.  
        <br />
        You can filter by any of the 5 fields in the Data column
        <br />
        Just use: "Contains"  
</td>
    </tr>
    <tr>
    <td><b>Filter the <i>Data</i> column using "Contains..."</b></td>
    <td>Single IP address: 
        <br />
        Choose the funnel Icon in the <i>Data</i> heading and 
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set <b><i>Contains:<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight: normal"> to</span> </i></b>&nbsp;&quot;140.11.22.33&quot;&nbsp;&nbsp; 
        </td>
    </tr>
    <tr>
    <td></td>
    <td>
        Range of IP addresses:  
        <br />
        Choose the funnel Icon in the Data heading and 
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set <b><i> Contains: 
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </i></b>  to:&nbsp;  "140.11."&nbsp;&nbsp; 
        </td>
    </tr>
    <tr><td></td>
    <td>Name Compaq: 
        <br />
        Choose the funnel Icon in the Data heading and 
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set <b><i> Contains: 
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </i></b>  to:&nbsp;  "Compaq"&nbsp;&nbsp; 
    </td>
    </tr>
    </table>
    <%});
       
               parent.Add()
                   .Text("Monitoring Coverage Help")
            .Content(() =>
            {%>
     <h2>About the Coverage Grid</h2>
   
    <table >
    <tr>
    <td>  
    <p>
    <b>This page is a reporting tool.</b>
     </p>  
    <ul>
       <li> <b>The grid shows all servers listed in ASSETCENTER </b></li> 
       <li> <b>Grid columns show whether the server is monitored or not and by which tool </b></li> 
    </ul>
     <ul>
        <li> You can sort by any column</li>
        <li> You can filter any column </li>
        <li> Group by any column with Drag-n-Drop </li>
        <li> It won&#39;t allow edits </li>
<!--        <li> The data is refreshed once a week&nbsp; (by Friday morning) </li> -->
     </ul>
</td>
    </tr>
    </table>

     
    <%});
                   //.LoadContentFrom("AjaxView_ExceptionalPerformance", "TabStrip");
           })
           .Render();    %>
</asp:Content>
