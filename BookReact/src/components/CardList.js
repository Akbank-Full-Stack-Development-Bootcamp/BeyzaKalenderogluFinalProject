import React, { } from "react";
import Card from "./Card";

const CardList = (props) => {
  
    return (
      <div className="row row-cols-1 row-cols-sm-2 row-cols-md-4 g-4">

        {
          props.books.map(function(book){
            return(
              <div className="col" key={book.id}>
                  <Card book={book}/>
              </div>
            )
          })
        }
        
      </div>
    );
  
}

export default CardList;
