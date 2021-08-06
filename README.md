# Dotnet API with Graphql using [GraphQL.NET](https://github.com/graphql-dotnet/graphql-dotnet)
* Code splitting.
* Data Loader implementation.

📣 *This is a self study project to allow me to better understand the `GraphQL` in the `.Net` environment and **not** a production ready API.*

👉The `RootQuery` and `RootMutation` are ***partial classes*** and the *queries* and *mutations* of the `Owner` and `Account` are an extension of them. By doing that we are improving our code organization.
The [GraphQL .NET](https://graphql-dotnet.github.io/docs/getting-started/query-organization) documentation explain how to do code organization in a different way, but the final result is a messy schema with queries and mutation aggregated by *entity*.

# References
* [Getting Started with GraphQL in ASP.NET Core](https://code-maze.com/graphql-aspnetcore-basics/)
* [Advanced GraphQL Queries, Error Handling, Data Loader](https://code-maze.com/advanced-graphql-queries/)
* [GraphQL Mutations in ASP.NET Core](https://code-maze.com/graphql-mutations/)
* [Architecture for ASP.NET Core Web API](https://medium.com/rocket-mortgage-technology-blog/implementing-an-effective-architecture-for-asp-net-core-web-api-254f95b8a434)

# Packages
* [Pomelo.EntityFrameworkCore.MySql](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql/5.0.0-alpha.2?_src=template)
* [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/5.0.1?_src=template)
* [GraphQL](https://www.nuget.org/packages/GraphQL/3.3.1?_src=template)
* [GraphQL.Server.Transports.AspNetCore](https://www.nuget.org/packages/GraphQL.Server.Transports.AspNetCore/4.4.1?_src=template)
* [GraphQL.Server.Transports.AspNetCore.SystemTextJson](https://www.nuget.org/packages/GraphQL.Server.Transports.AspNetCore.SystemTextJson/4.4.1?_src=template)
* [GraphQL.Server.Ui.Playground](https://www.nuget.org/packages/GraphQL.Server.Ui.Playground/4.4.1?_src=template)

# Paths

*Playground:* `/ui/playground`

*Gql endpoint:* `/graphql`

# Schema

````graphql
type Query {
  account(accountId: String!): Account
  accounts: [Account]
  owner(ownerId: String!): Owner
  owners: [Owner]
  roles: [Role]
  users: [User]
}

type Owner {
  accounts: [Account]

  # Address property from the owner object.
  address: String

  # Id property from the owner object.
  id: ID!

  # Name property from the owner object.
  name: String
}

type Account {
  # Description property from the account object.
  description: String

  # Id property from the account object.
  id: ID!
  owner: Owner

  # OwnerId property from the account object.
  ownerId: ID
  type: AccountTypeEnum
}

# Enumeration for the account type object.
enum AccountTypeEnum {
  CASH
  SAVINGS
  EXPENSE
  INCOME
}

type Role {
  # Role Code
  code: String

  # Role ID
  id: ID!

  # Role Name
  name: String
  users: [User]
}

type User {
  # User Name
  email: String

  # User ID
  id: ID!

  # User Name
  name: String
  role: Role

  # User Role ID
  roleId: ID

  # User Status
  status: UserStatusEnum
}

# Enumeration for the user status.
enum UserStatusEnum {
  NOT_ACTIVE
  ACTIVE
  BLOCKED
}

type Mutation {
  accountCreate(data: AccountInput!): Account
  accountDelete(accountId: ID!): String
  accountUpdate(data: AccountInput!, accountId: String!): Account
  ownerCreate(data: OwnerInput!): Owner
  ownerDelete(ownerId: ID!): String
  ownerUpdate(data: OwnerInput!, ownerId: String!): Owner
}

input OwnerInput {
  # Name property from the owner object.
  name: String!

  # Address property from the owner object.
  address: String
}

input AccountInput {
  type: AccountTypeEnum!

  # Description property from the account object.
  description: String

  # OwnerId property from the account object.
  ownerId: ID
}
````

# Queries example

````graphql
# Get all Owners
{
  owners{
    id
    address
    name
    accounts {
      id
      description
      ownerId
      type
    }
  }
}

# Get one Owner
{
  owner(ownerId: "3e85e4e3-d02a-4d52-ba80-83c34be6e233"){
    id
    address
    name
    accounts {
      id
      description
      ownerId
      type
    }
  }
}

# Get all Accounts
{
  accounts {
    id
    type
    description
    ownerId
    owner {
      id
      address
      name
    }
  }
}

# Get one Account
{
  account(accountId: "e58dc519-f9f7-414c-bb24-5252e1abc548") {
    id
    type
    description
    ownerId
    owner {
      id
      name
    }
  }
}
````

# Mutations example

````graphql
# Create an Owner
mutation ownerCreate {
  ownerCreate(data: { name: "New owner", address: "owner address" }) {
    id
    name
    address
    accounts {
      id
      description
      ownerId
      type
    }
  }
}

# Update an Owner
mutation ownerUpdate {
  ownerUpdate(
    ownerId: "60a7d9f7-22b8-4901-aed1-fc21e208d4a0"
    data: { name: "Update owner", address: "update address" }
  ) {
    id
    name
    address
    accounts {
      id
      description
      ownerId
      type
    }
  }
}

# Delete an Owner
mutation ownerDelete {
  ownerDelete(ownerId: "60a7d9f7-22b8-4901-aed1-fc21e208d4a0")
}

# Create one Account
mutation accountCreate {
  accountCreate(data: { description: "New owner", type: INCOME, ownerId: "5d3b52a0-d7ac-4584-a3d2-fde1f7905356" }) {
    id
    type
    description
    ownerId
    owner {
      id
      address
      name
    }
  }
}

# Update an Account
mutation accountUpdate {
  accountUpdate(
    accountId: "1d203454-ca82-4e00-8f8d-00e87b2c14ca"
    data: {
      description: "Update owner"
      type: EXPENSE
      ownerId: "5d3b52a0-d7ac-4584-a3d2-fde1f7905356"
    }
  ) {
    id
    type
    description
    ownerId
    owner {
      id
      address
      name
    }
  }
}

# Delete an Account
mutation accountDelete {
  accountDelete(accountId: "1d203454-ca82-4e00-8f8d-00e87b2c14ca")
}
````
