using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Tags : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DirectoryInfo directory = new DirectoryInfo(MapPath("~/Images/Catagories/"));
        FileInfo[] files = directory.GetFiles();

        List<string> tags = new List<string>();
        foreach (FileInfo file in files)
        {
            tags.Add(file.Name.Remove(file.Name.Count() - 4, 4));
        }
        tags.Sort(StringComparer.CurrentCulture);
        foreach (string tag in tags)
        {
            Tag.Text += "<a style='color:#00AAFF;' href='Images.aspx?Catagory=" + tag + "'>" + tag + "</a>" + "</br>";
        }

    }
}