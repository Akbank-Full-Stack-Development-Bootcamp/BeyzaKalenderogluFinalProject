import React, {  } from 'react'
import {Link} from 'react-router-dom'
const Card = (props) => {
    
      const{id, title, coverImagePath, price} = props.book
      
        return (
            <div className="card shadow-sm">
            <img className="image-fluid" src={coverImagePath} alt={title}/>

            <div className="card-body">
              <h5 className="card-title">{title}</h5>
              <div className="d-flex justify-content-between align-items-center">
                <div className="btn-group">
                 <Link to = {`/books/${id}`} className="btn btn-sm btn-outline-secondary">View</Link>
                </div>
                <small className="text-muted">{price} TL</small>
              </div>
            </div>
          </div>
        )
    
}

export default Card
