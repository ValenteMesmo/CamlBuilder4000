# CamlBuilder
<a href="https://github.com/ValenteMesmo/ValenteMesmo.CamlBuilder/actions?query=workflow%3A%22github-nuget-publish%22" rel="Build">![Build](https://github.com/ValenteMesmo/ValenteMesmo.CamlBuilder/workflows/github-nuget-publish/badge.svg)</a>
<a href="https://github.com/ValenteMesmo/ValenteMesmo.CamlBuilder/actions?query=workflow%3A%22org-nuget-publish%22" rel="Build">![Build](https://github.com/ValenteMesmo/ValenteMesmo.CamlBuilder/workflows/org-nuget-publish/badge.svg)</a>

Create caml query xmls for sharepoint with ease:
```C#
CamlBuilder.Where(f-> f.Number("Age").IsGreaterThan(18)).Build()
```