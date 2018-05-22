## TODO

### Frontend
- [ ] Create the CRUD views manually.
- [ ] Add a Bootstrap 4 theme.
- [ ] Add AJAX functionality to some or all of the forms.

### Backend
- [x] Setup different routes to showcase how to do it.
> _Check Movies/Index.cshtml page for an example. Basically you just need to define the route in the @page directive_      

```CSharp
@page "{id:int?}/{searchString?}"
...
public async Task OnGetAsync(string searchString, int? id)

``` 

- [ ] Organize the code into projects.


### Infrastructure
- [ ] Deploy to Azure / AWS.
- [ ] Setup CI/CD with tests associated with them.

### Reference
- [ ] __Read about [EF migrations](https://www.learnentityframeworkcore.com/migrations#reversing-a-migration) and [this](https://stackoverflow.com/questions/38192450/how-to-unapply-a-migration-in-asp-net-core-with-ef-core)__

> Restore the database to a given migtation
* Rollback to the migration which you want to by `Update-Database -Migration AddRenderColumn`
* `Remove-Migration`
* `Add-Migration SeedRatingData`
* Use the `Up` and `Down` methods to write the SQL to seed data. Refer __[this](https://stackoverflow.com/questions/33516705/change-data-in-migration-up-method-entity-framework)__
```CSharp
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql("UPDATE MOVIE SET RATING='R'");
}

protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql("UPDATE MOVIE SET RATING=NULL");
}
``` 
- [ ] Read [this](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/concurrency?view=aspnetcore-2.0) for a much data oriented tutorial and implement any missing features.


