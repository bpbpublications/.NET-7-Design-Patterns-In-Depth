<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="html" indent="yes"/>
  <xsl:strip-space elements="*"/>

  <xsl:template match="screen">
    <html>
      <body>
        <xsl:apply-templates/>
      </body>
    </html>
  </xsl:template>
  <xsl:template match="table">
    <table style="border-spacing:0">
      <xsl:apply-templates/>
    </table>
  </xsl:template>
  <xsl:template match="table/row">
    <xsl:variable name="bgcolor">
      <xsl:choose>
        <xsl:when test="position() mod 2 = 1">grey</xsl:when>
        <xsl:otherwise>white</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <tr bgcolor="{$bgcolor}">
      <xsl:apply-templates />
    </tr>
  </xsl:template>
  <xsl:template match="table/row/cell">
    <td>
      <xsl:apply-templates />
    </td>
  </xsl:template>
</xsl:stylesheet>
