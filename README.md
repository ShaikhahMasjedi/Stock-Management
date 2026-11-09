# 📦 Warehouse Management System

A desktop application for managing warehouse inventory, built with **C# and Windows Forms**. It helps track products, stock movements, suppliers, and customers in one place, with clear reports for better decision-making.

![Platform](https://img.shields.io/badge/platform-Windows-blue)
![Language](https://img.shields.io/badge/language-C%23-512bd4)
![Framework](https://img.shields.io/badge/.NET-WinForms-5c2d91)
![Database](https://img.shields.io/badge/database-SQL%20Server-cc2927)

---

## ✨ Features

- **Product management**: add, edit, delete, and search products with categories, units, and barcodes
- **Inventory tracking**: real-time stock quantities and low-stock alerts
- **Stock movements**: record incoming (purchases) and outgoing (sales/issues) transactions
- **Suppliers and customers**: manage contact details and transaction history
- **Warehouses**: support for multiple stores/warehouses and transfers between them
- **Reports**: stock balance, movement history, and low-stock reports, with print/export
- **User accounts and roles**: login with permission levels (Admin / Storekeeper)

> Adjust this list to match what your project actually includes.

---


## 🛠️ Tech Stack

- **Language:** C#
- **UI:** Windows Forms (.NET)
- **Database:** SQL Server
- **Data access:** ADO.NET *(or Entity Framework, whichever you used)*
- **Reports:** Crystal Reports / RDLC / DataGridView export *(choose one)*

---

## 📋 Requirements

- Windows 10 or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with the **.NET desktop development** workload
- [.NET SDK](https://dotnet.microsoft.com/download) (version used by the project)
- SQL Server (Express edition works) and SQL Server Management Studio (SSMS)

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/ShaikhahMasjedi/<repository-name>.git
cd <repository-name>
```

### 2. Set up the database

1. Open **SSMS** and connect to your SQL Server instance.
2. Restore the database from `Database/WarehouseDB.bak`, **or** run the script `Database/WarehouseDB.sql`.

### 3. Configure the connection string

Open `App.config` and update the connection string to match your server:

```xml
<connectionStrings>
  <add name="WarehouseDB"
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=WarehouseDB;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4. Build and run

1. Open the `.sln` file in Visual Studio.
2. Restore NuGet packages (right-click the solution → **Restore NuGet Packages**).
3. Press **F5** to run.

### Default login

| Username | Password |
|----------|----------|
| admin    | admin123 |

> ⚠️ Change the default credentials after the first login.

---

## 📁 Project Structure

```
WarehouseManagement/
├── Forms/            # Windows Forms (UI screens)
├── Models/           # Entity / data classes
├── DataAccess/       # Database access layer
├── Reports/          # Report definitions
├── Helpers/          # Utility classes
├── Database/         # SQL script / backup
├── screenshots/      # README images
└── App.config
```

> Update the folder names to match your solution.

---

## 🗺️ Roadmap

- [ ] Barcode scanner integration
- [ ] Export reports to Excel/PDF
- [ ] Backup and restore from within the app
- [ ] Multi-language support (Arabic / English)

---

## 🤝 Contributing

Contributions are welcome:

1. Fork the repository
2. Create a branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m "Add your feature"`
4. Push the branch: `git push origin feature/your-feature`
5. Open a Pull Request

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 👩‍💻 Author

**Shaikhah Sami Masjedi**
GitHub: [@ShaikhahMasjedi](https://github.com/ShaikhahMasjedi)
