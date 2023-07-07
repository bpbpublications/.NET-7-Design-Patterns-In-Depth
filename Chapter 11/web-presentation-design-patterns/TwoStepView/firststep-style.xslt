<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="authors">
    <screen>
      <table>
        <xsl:apply-templates/>
      </table>
    </screen>
  </xsl:template>
  <xsl:template match="author">
    <row>
      <xsl:apply-templates/>
    </row>
  </xsl:template>
  <xsl:template match="author/firstname">
    <cell>
      <xsl:apply-templates/>
    </cell>
  </xsl:template>
  <xsl:template match="author/lastname">
    <cell>
      <xsl:apply-templates/>
    </cell>
  </xsl:template>
  <xsl:template match="author/booksCount">
    <cell>
      <xsl:apply-templates/>
    </cell>
  </xsl:template>
</xsl:stylesheet>
