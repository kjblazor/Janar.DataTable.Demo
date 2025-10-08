# 📊 Janar.DataTable

A powerful, flexible, and modern data table component for **Blazor Server** and **MAUI Blazor Hybrid** apps.  
Built to support dynamic columns, rich formatting, searching, pagination, and **client-side export** — all styled with **Bootstrap 5**.

---

## ☕ Support

If you find this package helpful, please consider supporting me:

👉 [![Buy Me A Coffee](https://cdn.buymeacoffee.com/buttons/v2/default-green.png)](https://www.buymeacoffee.com/kjblazor)

---

## ✨ Features

- 🔄 **Dynamic Columns** via reflection  
- ⚙️ **Custom Column Configuration** (name, order, visibility)  
- ↕️ **Sortable Headers**  
- 🔍 **Search Filtering**  
- 📄 **Pagination**  
- 📤 **Export to CSV, Excel, and PDF (client-side)**  
- 🎨 **Bootstrap 5 Styling**  
- 🛠️ **Action Buttons Support** (Edit/Delete)  
- 🧩 **Custom Column Templates** via `RenderFragment`  

---

## 🚀 Getting Started

### ✅ Basic Usage

Use `Janar.DataTable` with auto-generated columns:

```razor
<DataTable TItem="Employee"
           Items="@employees" />
```

---

## ⚙️ Advanced Usage

### 1. 🛠️ Column Configuration

Define custom column headers, visibility, order, and templates:

```csharp
private List<ColumnConfiguration> columnConfigurations = new()
{
    new() { PropertyName = "Id", HeaderName = "ID", Order = 1, Visible = true },
    new() { PropertyName = "Name", HeaderName = "Full Name", Order = 2, Visible = true },
    new() { PropertyName = "Position", HeaderName = "Position", Order = 3, Visible = true },
    new() { PropertyName = "Office", HeaderName = "Office", Order = 4, Visible = true },
    new() { PropertyName = "Salary", HeaderName = "Salary", Order = 5, Visible = true, Template = customEmployee },
    new() { PropertyName = "JoiningDate", HeaderName = "Joining Date", Order = 6, Visible = true },
    new() { PropertyName = "LoginTime", HeaderName = "Login Time", Order = 7, Visible = true, Template = lgnTime },
    new() { PropertyName = "YearsAtCompany", HeaderName = "Years At Company", Order = 8, Visible = true }
};
```

```razor
<DataTable TItem="Employee"
           Items="@employees"
           ColumnConfigurations="@columnConfigurations" />
```

---

### 2. 🎯 Column Formatting

Format data (e.g., currency, dates, numbers) using `ColumnFormats`:

```csharp
private Dictionary<string, string> columnFormats = new()
{
    { "Salary", "C2" },               // $62,000.00
    { "JoiningDate", "dd-MMM-yyyy" }, // 10-Apr-2018
    { "YearsAtCompany", "N0" }        // 5
};
```

```razor
<DataTable TItem="Employee"
           Items="@employees"
           ColumnFormats="@columnFormats"
           ColumnConfigurations="@columnConfigurations" />
```

---

### 3. 🎨 Custom Templates with RenderFragment

Use `RenderFragment<T>` for custom rendering:

```csharp
private static RenderFragment<Employee> customEmployee => emp => builder =>
{
    builder.OpenElement(0, "span");
    builder.AddAttribute(1, "class", "btn btn-sm btn-primary me-2");
    builder.AddContent(2, emp.Salary.ToString("C0"));
    builder.CloseElement();
};

private static RenderFragment<Employee> lgnTime => emp => builder =>
{
    builder.OpenElement(0, "span");
    builder.AddAttribute(1, "class", "badge bg-info");
    builder.AddContent(2, emp.Logintime.ToString("HH:mm:ss"));
    builder.CloseElement();
};
```

```razor
<DataTable TItem="Employee"
           Items="@employees"
           ColumnConfigurations="@columnConfigurations" />
```

---

### 4. 🧰 Action Buttons (Edit/Delete)

Define handlers for editing and deleting rows:

```csharp
private void EditItem(Employee employee)
{
    // Handle edit logic here
}

private void DeleteItem(Employee employee)
{
    // Handle delete logic here
}
```

```razor
<DataTable TItem="Employee"
           Items="@employees"
           OnEdit="EditItem"
           OnDelete="DeleteItem" />
```

---

## 📦 Export Functionality

When `ExportButtons = true`, the component shows export buttons for CSV, Excel, and PDF.

### ✅ Required CSS

Include these in your layout file (e.g., `_Host.cshtml`, `App.cshtml`, `index.html`, or `MauiBlazorHostPage.xaml`):

```html
<link href="https://fonts.googleapis.com/icon?family=Material+Icons+Outlined" rel="stylesheet">
<link href="_content/Janar.Datatable/assets/css/datatable.css" rel="stylesheet" />
```

### ⚠️ Note

if you cannot find the CSS/JS files in `_content/Janar.Datatable/assets/`, download datatable.css from [🔗 GitHub Demo Repository](https://github.com/kjblazor/Janar.DataTable.Demo)

### ✅ Required Scripts

Place these before the closing `</body>` tag:

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
<script src="_content/Janar.Datatable/assets/js/datatable.js"></script>
<script src="_content/Janar.Datatable/assets/js/exporter.js"></script>
```

---

## 🧩 Component Parameters

| Parameter              | Type                         | Description                            |
| ---------------------- | ---------------------------- | -------------------------------------- |
| `TItem`                | `Type`                       | Generic item type (e.g., `Employee`)   |
| `Items`                | `IEnumerable<TItem>`         | Data source for the table              |
| `ColumnFormats`        | `Dictionary<string, string>` | Format strings per column              |
| `ColumnConfigurations` | `List<ColumnConfiguration>`  | Header, visibility, order, templates   |
| `OnEdit`               | `EventCallback<TItem>`       | Row Edit button callback               |
| `OnDelete`             | `EventCallback<TItem>`       | Row Delete button callback             |
| `ExportButtons`        | `bool`                       | Shows export buttons (CSV, Excel, PDF) |
| `ActionsButtons`       | `bool`                       | Shows Edit/Delete buttons              |
| `Search`               | `bool`                       | Enables search input                   |
| `TableStyle`           | `string`                     | Bootstrap classes to style the table   |
| `UndefinedColumns`     | `bool`                       | Auto-detect and display public props   |

---

## 🧪 Full Integration Example

```razor
<DataTable5 TItem="Employee"
            Items="@employees"
            ColumnConfigurations="@clmnOrderConfigs"
            OnEdit="EditEmployee"
            OnDelete="DeleteEmployee"
            ExportButtons="false"
            Search="false" 
            TableStyle="table-dark table-striped table-bordered"
            ActionsButtons="false"
            UndefinedColumns="false" />
```

---

## 🏗️ Column Configuration Example

```csharp
private List<ColumnConfigWithOrder<Employee>> clmnOrderConfigs = new()
{
    new() { PropertyName = "DefinedName", Visible = true, Header = "Name", Align = "left", Order = 1 },
    new() { PropertyName = "EmployeePosition", Visible = true, Header = "Position", Align = "center", Order = 2 },
    new() { PropertyName = "EmployeeSalary", Visible = true, Header = "Salary 💰", Align = "right", Order = 3,
             Template = employee => @<span class="text-success fw-bold">@employee.Salary.ToString("C0")</span> },
    new() { PropertyName = "EmployeeYearsAtCompany", Visible = true, Header = "Years @ Co.⏳", Align = "center", Order = 4,
             Template = employee => @<span class="badge bg-info">@employee.YearsAtCompany</span> }
};
```

* `Template` allows custom rendering using `RenderFragment<TItem>`
* `Align` controls text alignment (`left`, `center`, `right`)
* `Order` determines column display order
* `Visible` shows or hides the column

---

## ⚙️ Behavior: `UndefinedColumns`

* If `UndefinedColumns = true` (default):

  * All public properties on `TItem` are auto-detected and displayed
  * You can override properties via `ColumnConfigurations`

* If `UndefinedColumns = false`:

  * Only columns defined in `ColumnConfigurations` with `Visible = true` are shown

This gives you flexibility for both quick setup and fine-grained control.

---

## 🎨 Styling Tips

* Use the `TableStyle` parameter to apply Bootstrap classes:

```razor
TableStyle="table table-dark table-striped table-bordered"
```

* To add rounded corners:

```css
.table-wrapper {
    border-radius: 5px;
    overflow: hidden;
}
```

Wrap your `<table>` with a `.table-wrapper` div to enable rounded borders.

* Customize sorting icons by overriding classes like:

  * `.sort-indicator`
  * `.sort-arrow`
  * `.sort-active`
  * `.sort-disabled`

---

## ⚠️ .NET 8 Interactive Notice

If you're


using **Blazor Web Components** in **.NET 8**, ensure the component is rendered with an interactive render mode like:

```razor
@rendermode="InteractiveServer"
```

Otherwise, features such as **search**, **sort**, and **pagination** will not function.

---

## 📌 Versioning & Changes

When updating versions, ensure the following are reflected:

* ✅ Added Parameters:

  * `ExportButtons`
  * `ActionsButtons`
  * `Search`
  * `TableStyle`
  * `UndefinedColumns`

* ⚠️ Changed Behavior:

  * With `UndefinedColumns = true`, all columns are auto-detected unless configured

* 🎨 CSS & Styling Updates:

  * Improved dark mode support
  * Enhanced sorting styles
  * Better Bootstrap 5 compatibility

---

## 📚 GitHub Demo

[🔗 ![GitHub Demo Repository](https://github.githubassets.com/assets/GitHub-Mark-ea2971cee799.png)](https://github.com/kjblazor/Janar.DataTable.Demo)

---

## 🧾 License

MIT © [Janar Group]

---

## 🙏 Acknowledgments

* Uses [SheetJS](https://sheetjs.com/) for Excel exports
* Built with ❤️ by [Janar Group](https://www.janargroup.com/) using **Blazor** and **Bootstrap 5**

---

[![Buy Me a Coffee](https://cdn.buymeacoffee.com/buttons/v2/default-green.png)](https://www.buymeacoffee.com/kjblazor)

Thank you for using `Janar.DataTable`!

```
