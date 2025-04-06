# Conventies
## Inhoud
- [Code](#code)
- [Generiek](#generiek)
- [Naamgevingsconventies](#naamgevingsconventies)
- [Code Structuur](#code-structuur)
- [Documentatie](#documentatie)

## Code
### Generiek
- De code is in het Engels geschreven, dit betreft alle variabele, methode, klasse, etc. namen en commentaar.
- Commentaar wordt alleen toegevoegd om uit te leggen _waarom_ code is geschreven zoals het is, _niet_ om uit te leggen wat het doet. (Verwijder dus het commentaar dat AI schrijft!)
- Gebruik beschrijvende namen, _niet_ str, _maar_ playerName.
- Indentatie is 4 spaties, _niet_ tabs (kan ingesteld worden in je editor).
- Accolades worden op de volgende regel geplaatst.
- _Geen_ trailing comma's.
### Naamgevingsconventies
- Lokale variabele volgen camelCase, bijv.:
  - num.
  - currentOrder.
  - firstProduct.
- Eigenschappen volgen PascalCase, bijv.:
  - Name.
  - Username.
  - MinimumAge.
- Methodes volgen camelCase, bijv.:
  - getProduct.
  - addNumbers.
  - saveUser.
- Klassennamen volgen PascalCase, bijv.:
  - AppDataContext.
  - Order.
  - Product.
- Bestanden volgen dezelfde naamgevingsconventies als de bijbehorende klasse, bijv.:
    - Order.cs bevat de definitie van de Order-klasse.
    - Product.cs bevat de definitie van de Product-klasse.
    - User.cs bevat de definitie van de User-klasse.
### Code structuur
- Het projectbestand ([project naam].csproj) bevat de configuratie en afhankelijkheden van het project.
- Configuratiebestanden: Bestanden zoals App.xaml.cs zorgen voor de algemene instellingen van de applicatie.
- `Data/` Bevat de DataContext klasse en de `Models/` map.
- `Models/` Bevat de klassen.
- `Pages/` Bevat de Pages.
## Documentatie
- Documentatie wordt in het Nederlands geschreven, met uitzondering op vaktermen die moeilijk zijn te vertalen.
- Documenten bevatten de namen van de teamleden, de datum waarop het is geschreven, en een titel.
