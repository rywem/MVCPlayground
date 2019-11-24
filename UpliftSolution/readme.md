# Uplift

## Project Details
1. Authentication: Choose #2, In app authentication.

## Nuget Packages
1. Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 3.0.0
    1. Uplift  (MVC Web application project)
2. Microsoft.AspNetCore.Mvc 2.2.0
    1. Uplift.DataAccess
    2. Uplift.Models
3. Microsoft.AspNetCore.Mvc.NewtonsoftJson 3.0.0
    1. Uplift Project
4. Microsoft.EntityFrameworkCore 3.0.0
    1. Uplift.DataAccess 
5. Microsoft.Extensions.Identity.Stores 3.0.0
    1. Uplift.DataAccess
    2. Uplift.Models 
6. Microsoft.AspNetCore.Identity.EntityFrameworkCore
    1. Uplift
    2. Uplift.DataAccess
    3. Uplift.Models
7. Microsoft.EntityFrameworkcore.SqlServer 3.0.0
    1. Uplift.DataAccess

### Repository Pattern
1. Add scripts: 
    - Nuget Console
        - `add-migration AddCategoryToDatabase`
        - `add-migration AddFrequencyToDatabase`
2. Push scripts to database
    - Nuget Console:
        - `update-database`

### Resources
1. [Bootswatch](https://bootswatch.com/) - Bootstrap Wrapper Templates
2. [DataTables](https://datatables.net/) - Data table templates (includes CDN link)
    1. [DataTables CDN](http://cdn.datatables.net/) 
        - `//cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css`
        - `//cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js`
3. [Toastr](https://codeseven.github.io/toastr/) - Simple javascript toast notifications    
    - CDN
        - `//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js`
        - `//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css`
    - Nuget
    - [cdnjs toastr latest](https://cdnjs.com/libraries/toastr.js/latest)
    
4. [Sweet Alert](https://sweetalert.js.org/guides/) - Displays alerts
    - [cdnjs Sweet Alert 1.1.3](https://cdnjs.com/libraries/sweetalert/1.1.3)
5. [Font Awesome](https://fontawesome.com/) - Beautiful, free icons
6. [jQuery Serializer JSON](https://cdnjs.com/libraries/jquery.serializeJSON) - jQuery Serializer
    - `<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.serializeJSON/2.9.0/jquery.serializejson.min.js" integrity="sha256-A6ALIKGCsaO4m9Bg8qeVYZpvU575sGTBvtpzEFdL0z8=" crossorigin="anonymous"></script>`
    
```
CSS:

<link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css" />



JAVASCRIPT:

<script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
<script src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery.serializeJSON/2.9.0/jquery.serializejson.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
<script src="https://kit.fontawesome.com/99a0a84d2f.js" crossorigin="anonymous"></script>        
 ```