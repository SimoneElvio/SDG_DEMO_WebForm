<%@ Control Language="C#" AutoEventWireup="true" Inherits="GestioneUtenti.Web.Common.CustomerPagerControl" Codebehind="CustomerPagerControl.ascx.cs" %>
<style type="text/css">
	.igg_CustomPager
	{
		font-size: 11px;
		margin-right: 30px;
		background-color: transparent;
		/* you need to use the !important modifier, so that text-align: center remains after the update panel updates */
		text-align: center !important;
		vertical-align: middle;
		background-image: url(../images/pagerBG.gif);
	}
	.DropDownClass
	{
		font-size: 11px;
	}
	.igg_PageLink
	{
		border: 0px solid #ff0000;
		padding-left: 0px;
		padding-right: 0px;
	}
	.igg_CurrentPageLink
	{
		color: white;
		background-image: url(../images/customPager.png);
		background-repeat: no-repeat;
		padding-top: 6px;
		padding-left: 15px;
		padding-right: 15px;
		padding-bottom: 5px;
	}
</style>
<asp:ImageButton ID="ImageButton1" runat="server" CommandArgument="First" CommandName="Page"
	ImageUrl="../images/pagerFirst.gif" align="absmiddle" />
<asp:ImageButton ID="ImageButton2" runat="server" CommandArgument="Prev" CommandName="Page"
	ImageUrl="../images/pagerPrev.gif" align="absmiddle" />
Page
<asp:DropDownList ID="PagerPageList" runat="server" OnSelectedIndexChanged="PagerPageList_SelectedIndexChanged"
	AutoPostBack="True" CssClass="DropDownClass" />
of
<asp:Label ID="PageText" runat="server" />
<asp:ImageButton ID="ImageButton3" runat="server" CommandArgument="Next" CommandName="Page"
	ImageUrl="../images/pagerNext.gif" align="absmiddle" />
<asp:ImageButton ID="ImageButton4" runat="server" CommandArgument="Last" CommandName="Page"
	ImageUrl="../images/pagerLast.gif" align="absmiddle" />
