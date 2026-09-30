---
schema_version: 2
type: library
file_count: 34
delete_recommendation_percent: 5
generated_date: 2026-09-30
generated_time: 16:28:43
---

## Description

Knihovna pro generování kódu do více jazyků (C#, C++, SQL, TypeScript), vyčleněná z monolitu `SunamoDevCode`. Obsahuje generátory tříd (`CSharpClassesGenerator`), enum položek a generátory pro SQL a TypeScript.
Balíček je self-contained: kód dříve referencovaných balíčků (DevCodeBase, CSharp) je zkopírován do `Internal\` jako internal a jiné Sunamo balíčky nereferencuje.
