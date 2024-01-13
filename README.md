<h1>Projekt Końcowy</h1>
Eryk Olsza
14331

Temat projektu: Aplikacja do zarządzania zamówieniami i magazynem
<h2>Wymagania</h2>
<ul>
  <li>Co najmniej .Net 5</li>
  <li>Dotnet ef</li>
  <li>Program do zarządzania bazami danych (dla mnie Microsoft SQL Management Studio)</li>
</ul>

<h2>Instalacja</h2>
<ol>
  <li>Sklonować projekt.</li>
  <li>Stworzyć bazę danych i wziąć ConnectionString.</li>
  <li>Edytować appsettings.json wklejając ConnectionString w miejsce wartości w `WebAplicationDbContextConnection`</li>
  <li>W terminalu gdzie path kończy się na WebApplication1 wpisać komendę `dotnet ef database update`</li>
</ol>

