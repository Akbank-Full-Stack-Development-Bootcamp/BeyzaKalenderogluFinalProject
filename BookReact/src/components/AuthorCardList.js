import React, { } from "react";
import AuthorCard from "./AuthorCard";

const AuthorCardList = (props) => {
  
    return (
      <div className="row row-cols-1 row-cols-sm-2 row-cols-md-4 g-4">

        {
          props.authors.map(function(author){
            return(
              <div className="col" key={author.id}>
                  <AuthorCard author={author}/>
              </div>
            )
          })
        }
        
      </div>
    );
  
}

export default AuthorCardList;