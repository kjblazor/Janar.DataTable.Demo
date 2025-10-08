# 📊 Janar.DataTable

A powerful, flexible, and modern data table component for **Blazor Server** and **MAUI Blazor Hybrid** apps.  
Built to support dynamic columns, rich formatting, searching, pagination, and **client-side export** capabilities — all with **Bootstrap 5** styling.

---

You can also support me to build more Blazor components in future !

[![Buy Me A Coffee](https://cdn.buymeacoffee.com/buttons/v2/default-green.png)](https://www.buymeacoffee.com/kjblazor)

---
## ✨ Features

- 🔄 **Dynamic Columns** via reflection  
- ⚙️ **Custom Column Configuration** (name, order, visibility)  
- ↕️ **Sortable Headers**  
- 🔍 **Search Filtering**  
- 📄 **Pagination**  
- 📤 **Export to CSV, Excel, PDF (client-side)**  
- 🎨 **Bootstrap 5 Compatible**  
- 🛠️ **Action Buttons Support** (Edit/Delete)  
- 🧩 **Custom Column Templates** via RenderFragments  

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

Configure headers, visibility, order, and even render templates:

```csharp
private List<ColumnConfiguration> columnConfigurations = new()
{
    new ColumnConfiguration { PropertyName = "Id", HeaderName = "ID", Order = 1, Visible = true },
    new ColumnConfiguration { PropertyName = "Name", HeaderName = "Full Name", Order = 2, Visible = true },
    new ColumnConfiguration { PropertyName = "Position", HeaderName = "Position", Order = 3, Visible = true },
    new ColumnConfiguration { PropertyName = "Office", HeaderName = "Office", Order = 4, Visible = true },
    new ColumnConfiguration { PropertyName = "Salary", HeaderName = "Salary", Order = 5, Visible = true, Template = customEmployee },
    new ColumnConfiguration { PropertyName = "JoiningDate", HeaderName = "Joining Date", Order = 6, Visible = true },
    new ColumnConfiguration { PropertyName = "LoginTime", HeaderName = "Login Time", Order = 7, Visible = true, Template = lgnTime },
    new ColumnConfiguration { PropertyName = "YearsAtCompany", HeaderName = "Years At Company", Order = 8, Visible = true }
};
```

```razor
<DataTable TItem="Employee"
           Items="@employees"
           ColumnConfigurations="@columnConfigurations" />
```

---

### 2. 🎯 Column Formatting

Apply custom formats like currency, date, or number formatting:

```csharp
private Dictionary<string, string> columnFormats = new()
{
    { "Salary", "C2" },               // $62,000.00
    { "JoiningDate", "dd-MMM-yyyy" }, // 10-Apr-2018
    { "YearsAtCompany", "N0" }        // 5
};
```
📌 Use in DataTable component:

```razor
<DataTable TItem="Employee"
           Items="@employees"
           ColumnFormats="@columnFormats"
           ColumnConfigurations="@columnConfigurations" />
```

---

### 3. 🎨 Custom Templates (RenderFragment)

Use `RenderFragment<T>` for rendering custom content in any column:

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
📌 Use in DataTable component:

```razor
<DataTable TItem="Employee"
           Items="@employees"
           ColumnConfigurations="@columnConfigurations" />
```

---

### 4. 🧰 Action Buttons (Edit/Delete)

Define event handlers for row actions:

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
📌 Use in DataTable component:

```razor
<DataTable TItem="Employee"
           Items="@employees"
           OnEdit="EditItem"
           OnDelete="DeleteItem" />
```

---

## 📦 Export Support (CSV / Excel / PDF)

To enable export functionality, you must include the required CSS and JS files.

### 📄 Stylesheet
Add this in your layout file (`_Host.cshtml`, `App.cshtml`, `index.html`, or `MauiBlazorHostPage.xaml`):

```html
<!-- Janar DataTable CSS -->
<link href="https://fonts.googleapis.com/icon?family=Material+Icons+Outlined" rel="stylesheet">
<link href="_content/Janar.Datatable/assets/css/datatable.css" rel="stylesheet" />
```

### 📜 Scripts

Add these before the closing `</body>` tag:

```html
<!-- For Excel Download -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
<script src="_content/Janar.Datatable/assets/js/datatable.js"></script>
<script src="_content/Janar.Datatable/assets/js/exporter.js"></script>

```

---

## 📘 Example: Full Integration

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

## 💡 Tips

* Set `Order` in `ColumnConfiguration` to control display sequence.
* Use `Visible = false` to hide specific fields.
* `Template` overrides default rendering and formatting.
* Leverage Bootstrap 5 classes (`btn`, `badge`, etc.) for styling custom fragments.

## For Better Look and Feel

Include latest **Bootstrap** CSS in your project by adding the following link to your HTML `<head>` section:

```html
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
```

##  ⚠️ **Search Functionality Notice:**  

* If you're using Blazor Web Components in .NET 8, it's **mandatory** to render the `DataTable` with `@rendermode="InteractiveServer"` or any interactive mode, or else features like **search**, **sort**, and **pagination** will not work.


---

## 🧱 Component Parameters

| Parameter              | Type                         | Description                              |
| ---------------------- | ---------------------------- | ---------------------------------------- |
| `TItem`                | `Type`                       | Generic item type (e.g., `Employee`)     |
| `Items`                | `IEnumerable<TItem>`         | Data to display                          |
| `ColumnFormats`        | `Dictionary<string, string>` | Format strings per column                |
| `ColumnConfigurations` | `List<ColumnConfiguration>`  | Column name, visibility, order, template |
| `OnEdit`               | `EventCallback<TItem>`       | Event for Edit button                    |
| `OnDelete`             | `EventCallback<TItem>`       | Event for Delete button                  |
| `ExportButtons`        | `bool`                       | If `true`, shows the CSV / Excel / PDF export buttons  |
| `ActionsButtons`       | `bool`                       | If `true`, shows the Edit / Delete buttons column      |
| `Search`               | `bool`                       | If `true`, shows the search input box                  |
| `TableStyle`           | `string`                     | Bootstrap table classes (and your custom ones like `"table-bordered table-hover table-striped"`) to style the table   |
| `UndefinedColumns`     | `bool`                       | If `true`, all public properties of `TItem` are auto-displayed (unless explicitly hidden). If `false`, only those columns defined in `ColumnConfigurations` with `Visible = true` are shown, defalt value `false`. |

---

## Column Configuration Example

```csharp
private List<ColumnConfigWithOrder<Employee>> clmnOrderConfigs = new()
{
    new() { PropertyName = "DefinedName", Visible = true, Header = "Name", Align = "left", Order = 1 },
    new() { PropertyName = "EmployeePosition", Visible = true, Header = "Position", Align = "center", Order = 2 },
    new() { PropertyName = "EmployeeSalary", Visible = true, Header = "Salary 💰", Align = "right", Order = 3,
             Template = employee => @<span class="text-success fw-bold">@employee.Salary.ToString("C0")</span> },
    new() { PropertyName = "EmployeeYearsAtCompany", Visible = true, Header = " Years @ Co.⏳", Align = "center", Order = 4,
             Template = employee => @<span class="badge bg-info">@employee.YearsAtCompany</span> }
};
```

* You can specify a `Template` (a `RenderFragment<TItem>`) to customize cell rendering.
* `Align` controls text alignment (e.g. `"left"`, `"center"`, `"right"`).
* `Order` sets the column display order.
* `Visible` lets you show or hide individual columns.

---

## Behavior of `UndefinedColumns`

* When `UndefinedColumns = true` (default), the component will **auto-detect all public properties** on `TItem` and display them — applying your `ColumnConfigurations` for any overrides (header, template, alignment, visibility).
* When `UndefinedColumns = false`, only the columns you explicitly define (with `Visible = true`) in `ColumnConfigurations` are shown — all other public properties are ignored.

This gives you flexibility: rapid prototyping when you want everything shown, and precise control when you want minimal columns.

---

## Styling & Customization Tips

* Use the `TableStyle` parameter to apply Bootstrap classes (e.g., `"table table-dark table-striped table-bordered"`).

* To achieve rounded corners:

  ```css
  .table-wrapper {
      border-radius: 5px;
      overflow: hidden;
  }
  ```

  Wrap your `<table>` in a div with `.table-wrapper` to apply corner rounding (especially when using `.table-bordered`).

* For sort icons and modern UI, override CSS classes like `.sort-indicator`, `.sort-arrow`, `.sort-active`, `.sort-disabled` to match your app’s theme.

---

## Export Functionality

When `ExportButtons = true`, the component renders buttons to export the entire filtered dataset to CSV, Excel, or PDF. You can disable this if you don’t want export in some pages.

---

## Versioning & Changes

When updating versions, make sure to reflect:

* Added parameters: `ExportButtons`, `ActionsButtons`, `Search`, `TableStyle`, `UndefinedColumns`
* Changed default behavior: With `UndefinedColumns = true`, all columns are auto-detected
* CSS and styling changes (especially for dark mode, sort behavior, etc.)

---

## Github Repository Demo

[Github Demo](https://github.com/kjblazor/Janar.DataTable.Demo)

---
## 🧾 License

MIT © [Janar Group]

---

## 🙏 Acknowledgments

* Uses [SheetJS](https://sheetjs.com/) for Excel exports
* Built with ❤️ by `[Janar Group](https://www.janargroup.com/)` using Blazor and Bootstrap 5

---

[![Buy Me a Coffee](https://cdn.buymeacoffee.com/buttons/v2/default-green.png)](https://www.buymeacoffee.com/kjblazor)

Thank you !

---
