# CabBooking

<p>Using .Net Core Web API and Angular</p>

<p>In this project, there are five pages, the home page shows the all cab types with clickable name that can direct to the booking detail page for that car. Also, there are four buttons on the navigation that allow user to do CRUD operation for each table. In the CRUD operation page, user can insert the data by submit the form, and user can modify or delete the data by click the buttons attached to the record. Once user click the edit button, the data will automatically fill up in the form, and user can use the same button as insert to update the data.<p>

<p>There are three projects in the Solution. In CabsBooking.Core project, it contains repostiory interface, service interface, entity and model. In CabsBooking.Infrastructure project, it contains repository implementation, service inplementation, and database managment by using migration. In CabsBooking.API project, it contains controller to call the implementation from service and sending the http response.</p>

<p>To use the project, remembering modify the Connection string in appsetting.json file which is located in CabsBooking.API. After that, please checking your localhost for API and angular and modifying the addresses for both of them. The API address is in the environment file located in ngCabsBooking.SPA, and the angular address is in the appsetting.json located in CabsBooking.API. </p>
