import React from 'react'
import CategoryBookCard from "./CategoryBookCard"

function CategoryBookCardList(props) {
    return (
        <div className="row row-cols-1 row-cols-sm-2 row-cols-md-4 g-4">

          {
            props.categoryBooks.map(function(categoryBook){
              return(
                <div className="col" key={categoryBook.id}>
                    <CategoryBookCard categoryBook={categoryBook}/>
                </div>
              )
            })
          }
          
        </div>
    )
}

export default CategoryBookCardList
