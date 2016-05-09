<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="spinner.ascx.cs" Inherits="LargeDealFrameWork.spinner" %>

<script runat="server">
private int m_minValue;
private int m_maxValue = 100;
private int m_currentNumber = 0;
public int MinValue
{
    get
    {
        return m_minValue;
    }
    set
    {
        if(value >= this.MaxValue)
        {    
            throw new Exception("MinValue must be less than MaxValue.");
        }
        else
        {
            m_minValue = value;
        }
    }
}

public int MaxValue
{
    get
    {
        return m_maxValue;
    }
    set
    {
        if(value <= this.MinValue)
        {
            throw new 
                Exception("MaxValue must be greater than MinValue.");
        }
        else
        {
            m_maxValue = value;
        }
    }
}

public int CurrentNumber
{
    get
    {
        return m_currentNumber;
    }
}

protected void Page_Load(Object sender, EventArgs e)
{
    if(IsPostBack)
    {
        m_currentNumber =
            Int16.Parse(ViewState["currentNumber"].ToString());
    }
    else
    {
        m_currentNumber = this.MinValue;
    }
    DisplayNumber();
}

protected void DisplayNumber()
{
    txt1.Text = this.CurrentNumber.ToString();
    ViewState["currentNumber"] = this.CurrentNumber.ToString();
}

protected void btn1_Click(Object sender, EventArgs e)
{
    if(m_currentNumber == this.MaxValue)
    {
        m_currentNumber = this.MinValue;
    }
    else
    {
        m_currentNumber += 1;
    }
    DisplayNumber();
}

protected void btn2_Click(Object sender, EventArgs e)
{
    if(m_currentNumber == this.MinValue)
    {
        m_currentNumber = this.MaxValue;
    }
    else
    {
        m_currentNumber -= 1;
    }
    DisplayNumber();
}
</script>


<table style="width:25%; height:10%">
<tr style="width:10%; height:15%">
<td style="width:10%; height:15%">
<asp:TextBox ID="txt1" runat="server" Width="100%" Height="50%"></asp:TextBox>
</td>
<td style="width:10%; height:15%">
<asp:Button ID="btn1" runat="server" Text="^" Width="100%" Height="20%" 
        onclick="btn1_Click" />
<br />
<asp:Button ID="btn2" runat="server" Text="v" Width="100%" Height="20%" 
        onclick="btn2_Click" />
</td>
</tr>

</table>
