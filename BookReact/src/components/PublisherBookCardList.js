import React, {  } from 'react'
import PublisherBookCard from "./PublisherBookCard"

const PublisherBookCardList = (props) => {
    
      
        return (
          <div className="row row-cols-1 row-cols-sm-2 row-cols-md-4 g-4">

          {
            props.publisherBooks.map(function(publisherBook){
              return(
                <div className="col" key={publisherBook.id}>
                    <PublisherBookCard publisherBook={publisherBook}/>
                </div>
              )
            })
          }
          
        </div>
        )
    
}

export default PublisherBookCardList