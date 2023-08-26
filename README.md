## PROJECT AND USED TECHNOLOGIES
The Course Mate project is an initiative that brings students and teachers together on a digital platform. While teachers can create various courses according to their interests, students can attend these courses and get support on the issues they lack. The project brings together people from different cultures by creating a global community while offering flexible learning opportunities

This project is built on a layered architectural structure. This structure is basically the communication of 4 separate layers with each other. These layers are Entities, Data Access, Business and WEB API layers, respectively. Apart from these, there is another layer called Core and this layer contains structures that can be used in common in the project. Nuget is used for the management of outsourcing packages in Backend.

You can find application codes and interface images in frontend codes.
Frontend Codes Link: <https://github.com/eyupduran/Course-Mate-fe>

#### LAYERS AND HOW TO WORK
##### Entities Layer

This layer, as the name suggests, is the section where database entities are defined within classes. Each database object is represented in this layer through related classes. In the Core layer, an interface named IEntity is defined to hold references to these classes, and database entity classes implement these interfaces.

Also in this layer is the DTO structure that holds the models of database queries. DTOs move data received from or sent to a database and are often associated with database tables. In this way, database operations can be performed more regularly and easily.
##### Data Access Layer
This layer is used to communicate with the database. External packages such as Entity Framework are used to perform database operations. In this layer, there are two folders named Concrete and Abstract.

The abstract folder contains the interface that allows to manage the data communication codes for each entity. These interfaces implement the IEntityRepository<T> interface, which quickly performs CRUD operations using the Entity Framework at the Core layer. The <T> expression here is a Generic expression and represents the type used for the related entity.

The Concrete folder contains the corresponding concrete classes of the interfaces in the Abstract folder. These classes implement the corresponding interfaces in the Abstract folder. Also in this folder is a database connection called ETradeContext and a class that determines how entities are mapped to the database.
##### Business Layer
This layer is the layer where the services are located. As in the Data Access layer, folders are made as Abstract and Concrete.

The abstract folder contains the service interfaces of the related classes and contains the names of the service methods whose entity it wants to use.

In the Concrete folder, there are concrete classes corresponding to these interfaces. The interfaces of the related entity in the data access layer are injected into the consturctors of these classes with the dependency injection method. By implementing the relevant interface, the methods in the interface are populated with the help of the configured data access interfaces.

In this layer, Autofac technique is used to improve dependency injection. In addition, Autofac and MethodInterception techniques, which we want to run before or after the methods in the service, have been applied.

Also, a folder named ValidationRules has been created in this layer. An entity validator was written using Fluent Validation downloaded with NuGet. This validator determines the validation rules of the related entity with the help of Fluent Validation.

##### WEB API Layer
This layer is the API layer that enables the methods in the Business layer to be opened to the outside world. In this layer, all entities have controllers. These controllers have methods associated with API request headers. By injecting the interface of the related entity in the business layer with the dependency injection method, these methods perform data receiving or sending data from the methods in the business layer. In the frontend, API requests are implemented with the names written at the beginning of these methods.

This layer may also be called "Business Orientation and Control". This layer directs the incoming requests to the correct business methods and ensures that the work is done. Business logic-specific operations are performed in this layer and the results are presented to the outside world.

The API layer provides an interface that is available to clients. Users can exchange data or perform transactions by making API requests through this interface. Requests are transmitted using the HTTP protocol and processed by the respective controllers.
##### Core Layer
This layer contains structures that can be used in common throughout the project. I have mentioned this layer in other layers. This layer contains interfaces that reference entities and DTOs. The Cross Cutting Concerns technique, which I used in the project, is included with the aspect structure in this layer. In addition, method interceptors are also located in this layer.
The methods created to ensure the security of the application are also included in this layer. These methods are the methods in which the user password is encrypted with the MD5 Hash algorithm and the JWT token is generated, and they are called and used during the user registration and login operations.