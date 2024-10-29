<p>Phần mềm sử dụng <b>BE(Server)</b> với <b>ASP.NET Core Web API</b>, <b>FE(Client)</b> với <b>Blazor Web App (WebAssembly)</b>, Các thuộc tính của class nằm trong <b>Shared</b> chứa các <b>Entities(Models)</b></p>
<p>Phân mềm chạy chương trình <b>Visual Studio 2022</b>, <b>SQL Server Express 2019</b></p>
<p>Trong <b>Visual Studio Installer</b>, tải <b>ASP.NET and web development</b> và <b>.NET destop development</b></p>
<p>Vào <b>SQL server</b>, trong mục <b>database</b>, click phải chọn <b>import data-tier application</b> chọn vào file <b>OpenSouce.bacpac</b></p>
<p>Vào <b>Visual Studio</b> chọn vào file đã tải, click vào <b>OpenSourceSolution.sln</b> sau đó vào file <b>appsetting.js</b> của <b>OpenSource.Server</b> sửa lại <b>Server=....</b> bằng tên server name của Sql server</p>
<p>Sau đó click chạy trên thanh menu</p>
<p><b>NẾU</b> không cần dữ liệu, có thể vô <b>Tools -> NuGet Package Manager -> Package Manager Console</b> sau đó chạy dòng lệnh <b>Update-Database</b>. Sau đó cũng chạy như trên</p>
