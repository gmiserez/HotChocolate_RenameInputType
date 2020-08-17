
# Summary
***
Sample Repository for the [HotChocolate Bug 2229](https://github.com/ChilliCream/hotchocolate/issues/2229)


# Instructions
- Adapt the Portnumber in the Stitching App to the port that will be used by your "StarWars" app.
- Run both Apps in the solution
- Run the following mutation:
```
mutation cr {
  createReviewWithRenamedInputType(input: {commentary: "foo", episode: NEWHOPE, stars: 3}) {
    episode
    review {
      id
    }
  }
}
```
