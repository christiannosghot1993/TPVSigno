<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Test.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <ext:XScript runat="server" ID="xScript">
        <script type="text/javascript">
            var GetImage = function (value) {
                return "<img src='images/" + value + ".jpg' />";
            }
        </script>
    </ext:XScript>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="res" runat="server">
    </ext:ResourceManager>
    <div>
        <ext:GridPanel ID="GridPanel1" runat="server" StripeRows="true" Title="Cocktails"
            Width="300" Height="600" Visible="true">
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:Column ID="ID" Text="Image" DataIndex="ID" Width="125">
                        <Renderer Fn="GetImage" />
                    </ext:Column>
                    <ext:Column Header="Name" DataIndex="Name">
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <Store>
                <ext:Store ID="Store1" runat="server">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="ID" />
                                <ext:RecordField Name="Name" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
        </ext:GridPanel>
    </div>
    </form>
</body>
</html>
