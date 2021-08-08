import React, {  } from 'react'
import AuthorBookCard from "./AuthorBookCard"

const AuthorBookCardList = (props) => {
    
      
        return (
          <div className="row row-cols-1 row-cols-sm-2 row-cols-md-4 g-4">

          {
            props.authorBooks.map(function(authorBook){
              return(
                <div className="col" key={authorBook.id}>
                    <AuthorBookCard authorBook={authorBook}/>
                </div>
              )
            })
          }
          
        </div>
        )
    
}

export default AuthorBookCardList