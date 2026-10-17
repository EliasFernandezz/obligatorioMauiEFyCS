# 📻 App Móvil para Emisora de Radio FM — .NET MAUI

🇪🇸 [Español](#-español) · 🇬🇧 [English](#-english)

---

# 🇪🇸 Español

Aplicación multiplataforma desarrollada con **.NET MAUI** para una emisora de radio FM de Punta del Este: radio en vivo, noticias, clima, cotizaciones, cine y gestión de patrocinadores en una sola app.

## Contexto

Proyecto académico grupal (obligatorio de **Taller de Tecnologías**, 2025), desarrollado en **CEI** (Analista Programador), en convenio con la **Universidad CLAEH**, por un equipo de dos personas. El objetivo era construir una app con experiencia intuitiva y estética en tonos azules, consumiendo servicios externos para ofrecer contenido actualizado a los oyentes de la emisora.

## Funcionalidades

- **Registro e inicio de sesión:** registro con nickname único, datos personales y foto de perfil (cámara o galería). Inicio de sesión con usuario y contraseña, o con **huella dactilar** en teléfonos.
- **Página principal:** saludo con el nickname, foto de perfil (o una por defecto) y **radio en vivo por streaming**.
- **Clima:** estado actual y pronóstico para Punta del Este.
- **Cine:** películas en tendencia de la semana, con búsqueda por género o palabra clave.
- **Cotizaciones:** valor del dólar, el euro y el real brasileño frente al peso uruguayo.
- **Noticias:** noticias actuales de Uruguay, con imagen y resumen.
- **Patrocinadores:** alta (nombre, logo y ubicación), listado, eliminación y vista de mapa. En el teléfono la ubicación se elige en un **mapa interactivo**; en computadora se ingresa con latitud y longitud.
- **Preferencias:** cada usuario elige qué secciones ver en el menú de navegación.
- **Adaptación por dispositivo:** la interfaz cambia según sea teléfono o escritorio (por ejemplo, huella y mapa solo en teléfono, y distinta cantidad de columnas en la lista de películas).

## Tecnologías

| Área | Herramientas |
|---|---|
| Framework | .NET 8, .NET MAUI, C#, XAML |
| Datos | SQLite (`sqlite-net-pcl`) para usuarios y patrocinadores |
| Librerías | CommunityToolkit.Maui.MediaElement (radio), Microsoft.Maui.Controls.Maps (mapa), Plugin.Fingerprint (huella), Newtonsoft.Json |
| APIs | OpenWeatherMap, CurrencyLayer, NewsData.io, TheMovieDB, Google Maps |
| Herramientas | Git y GitHub (ramas `main`, `develop` y varias `feature`), Postman, QuickType |

## Mi aporte

- Desarrollé el registro y el inicio de sesión, incluida la autenticación con huella dactilar, con persistencia de usuarios en SQLite.
- Integré las APIs de noticias (NewsData.io) y de cotizaciones (CurrencyLayer).
- Implementé el menú de preferencias, la radio en vivo y la página principal con el nickname y la foto de perfil del usuario.
- Armé la estructura inicial de la app (navegación entre páginas y paleta de colores) y el diseño responsive para teléfono y escritorio.
- Configuré el mapa en Android, activándolo solo en teléfonos.

## Cómo ejecutarlo

**Requisitos:** Visual Studio 2022 con la carga de trabajo *.NET Multi-platform App UI development*, .NET 8, y un emulador o dispositivo Android (o Windows 10/11).

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/EliasFernandezz/obligatorioMauiEFyCS.git
   ```
2. Abrir `obligatorioMauiEFyCS.sln` en Visual Studio y restaurar los paquetes NuGet.
3. Configurar tus propias claves de API (ver más abajo).
4. Seleccionar Android o Windows como destino y ejecutar.

### Claves de API

La app necesita una clave propia para cada servicio (todos tienen plan gratuito). Reemplazá el valor en el archivo indicado:

| Servicio | Archivo |
|---|---|
| [OpenWeatherMap](https://openweathermap.org/api) | `Clima.xaml.cs` |
| [CurrencyLayer](https://currencylayer.com/) | `Cotizaciones.xaml.cs` |
| [NewsData.io](https://newsdata.io/) | `Noticias.xaml.cs` |
| [TheMovieDB](https://www.themoviedb.org/documentation/api) | `Cine.xaml.cs` |
| [Google Maps (Android)](https://developers.google.com/maps) | `Platforms/Android/AndroidManifest.xml` |

> Reemplazá los valores por tus propias claves de API.

## Estructura del proyecto

```
obligatorioMauiEFyCS/
├── DB Models/     # Entidades de base de datos (Usuario, Patrocinador)
├── Models/        # Modelos de las respuestas de las APIs (generados con QuickType)
├── Service/       # Autenticación, sesión de usuario y acceso a datos de patrocinadores
├── Platforms/     # Configuración específica de Android, iOS, macOS y Windows
├── Resources/     # Imágenes, fuentes y estilos
└── *.xaml(.cs)    # Páginas: Login, Registro, MainPage, Clima, Cine, Cotizaciones,
                   # Noticias, Preferencias y gestión de patrocinadores
```

## Desafíos y aprendizajes

- Trabajar con una tecnología nueva para el equipo, aprendiendo de forma autodidacta.
- Integrar cinco APIs externas con respuestas JSON distintas.
- Adaptar la app a distintos dispositivos (teléfono y escritorio) dentro de un mismo proyecto.
- Cumplir con los requerimientos en un plazo reducido.

## Mejoras futuras

- Guardar las contraseñas con hash y no en texto plano.
- Mover las claves de API a un archivo de configuración fuera del repositorio.
- Separar la lógica de las páginas con el patrón MVVM.
- Agregar pruebas automatizadas.

## Equipo

- **Elías Fernández** — [GitHub](https://github.com/EliasFernandezz)
- **Catherine Sonderegger** — [GitHub](https://github.com/CathGirL1)

---

# 🇬🇧 English

A cross-platform application built with **.NET MAUI** for an FM radio station in Punta del Este, Uruguay: live radio, news, weather, exchange rates, movies and sponsor management in a single app.

## Context

Group academic project (**Technology Workshop** assignment, 2025), developed at **CEI** (Programmer Analyst program) in partnership with **Universidad CLAEH**, by a team of two. The goal was to build an app with an intuitive experience and a blue-toned design, consuming external services to deliver up-to-date content to the station's listeners.

## Features

- **Sign-up and login:** registration with a unique nickname, personal details and a profile picture (camera or gallery). Login with username and password, or **fingerprint** on phones.
- **Home page:** greeting with the user's nickname, profile picture (or a default one) and a **live streaming radio player**.
- **Weather:** current conditions and forecast for Punta del Este.
- **Movies:** this week's trending movies, searchable by genre or keyword.
- **Exchange rates:** value of the US dollar, euro and Brazilian real against the Uruguayan peso.
- **News:** current news from Uruguay, with image and summary.
- **Sponsors:** create (name, logo and location), list, delete and map view. On phones the location is picked on an **interactive map**; on desktop it is entered as latitude and longitude.
- **Preferences:** each user chooses which sections appear in the navigation menu.
- **Device adaptation:** the UI changes between phone and desktop (e.g. fingerprint and map on phones only, and a different number of columns in the movie list).

## Tech Stack

| Area | Tools |
|---|---|
| Framework | .NET 8, .NET MAUI, C#, XAML |
| Data | SQLite (`sqlite-net-pcl`) for users and sponsors |
| Libraries | CommunityToolkit.Maui.MediaElement (radio), Microsoft.Maui.Controls.Maps (map), Plugin.Fingerprint (fingerprint), Newtonsoft.Json |
| APIs | OpenWeatherMap, CurrencyLayer, NewsData.io, TheMovieDB, Google Maps |
| Tooling | Git and GitHub (`main`, `develop` and several `feature` branches), Postman, QuickType |

## My Contribution

- Built sign-up and login, including fingerprint authentication, with user persistence in SQLite.
- Integrated the news (NewsData.io) and exchange rate (CurrencyLayer) APIs.
- Implemented the preferences menu, the live radio player and the home page showing the user's nickname and profile picture.
- Set up the app's initial structure (page navigation and color palette) and the responsive design for phone and desktop.
- Configured the map on Android, enabling it on phones only.

## Getting Started

**Requirements:** Visual Studio 2022 with the *.NET Multi-platform App UI development* workload, .NET 8, and an Android emulator or device (or Windows 10/11).

1. Clone the repository:
```bash
   git clone https://github.com/EliasFernandezz/obligatorioMauiEFyCS.git
```
2. Open `obligatorioMauiEFyCS.sln` in Visual Studio and restore the NuGet packages.
3. Set up your own API keys (see below).
4. Select Android or Windows as the target and run.

### API Keys

The app needs your own key for each service (all offer a free tier). Replace the value in the file indicated:

| Service | File |
|---|---|
| [OpenWeatherMap](https://openweathermap.org/api) | `Clima.xaml.cs` |
| [CurrencyLayer](https://currencylayer.com/) | `Cotizaciones.xaml.cs` |
| [NewsData.io](https://newsdata.io/) | `Noticias.xaml.cs` |
| [TheMovieDB](https://www.themoviedb.org/documentation/api) | `Cine.xaml.cs` |
| [Google Maps (Android)](https://developers.google.com/maps) | `Platforms/Android/AndroidManifest.xml` |

> Replace the values with your own API keys.

## Project Structure

```
obligatorioMauiEFyCS/
├── DB Models/     # Database entities (Usuario, Patrocinador)
├── Models/        # API response models (generated with QuickType)
├── Service/       # Authentication, user session and sponsor data access
├── Platforms/     # Android, iOS, macOS and Windows specific setup
├── Resources/     # Images, fonts and styles
└── *.xaml(.cs)    # Pages: Login, Registro, MainPage, Clima, Cine, Cotizaciones,
                   # Noticias, Preferencias and sponsor management
```

## Challenges & Learnings

- Working with a technology new to the team, learning it independently.
- Integrating five external APIs with different JSON responses.
- Adapting the app to different devices (phone and desktop) within a single project.
- Meeting the requirements within a tight deadline.

## Future Improvements

- Store passwords hashed instead of in plain text.
- Move API keys to a configuration file kept out of the repository.
- Separate page logic using the MVVM pattern.
- Add automated tests.

## Team

- **Elías Fernández** — [GitHub](https://github.com/EliasFernandezz)
- **Catherine Sonderegger** — [GitHub](https://github.com/CathGirL1)
