import React, { } from "react";
import PublisherCard from "./PublisherCard";

const PublisherCardList = (props) => {
  
    return (
      <div className="row row-cols-1 row-cols-sm-2 row-cols-md-4 g-4">

        {
          props.publishers.map(function(publisher){
            return(
              <div className="col" key={publisher.id}>
                  <PublisherCard publisher={publisher}/>
              </div>
            )
          })
        }
        
      </div>
    );
  
}

export default PublisherCardList;