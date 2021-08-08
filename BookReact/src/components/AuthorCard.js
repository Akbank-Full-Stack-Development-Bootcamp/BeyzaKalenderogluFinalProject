import React, {  } from 'react'
import {Link} from "react-router-dom"

const   AuthorCard = (props) => {
    

      const{id, name, lastname, about,imgPath} = props.author
      const truncateString = (str,num) => {
        if(str.length > num){
            return str.slice(0, num) + "...";
        }else{
            return str;
        }
    }
        return (
            <div className="card shadow-sm">
            <img src={imgPath} alt={name}/>

            <div className="card-body">
              <h5 className="card-title">{name} {lastname}</h5>
              <div className="d-flex justify-content-between align-items-center">
              <p className="card-text">{truncateString(about, 20)}</p>
                <div className="btn-group">
                <Link to={`/authors/${id}`}><button type="button" className="btn btn-sm  btn-outline-secondary">View Books</button></Link>
                </div>
              </div>
            </div>
          </div>
        )
    
}

export default AuthorCard
