import React from 'react'
import {Link} from 'react-router-dom'

const CategoryBookCard = (props) => {
    const{id, title, coverImagePath, price} = props.categoryBook
        return (
            <div className="card shadow-sm">
            <img src={coverImagePath} alt={title} />
            <div className="card-body">
              <h5 className="card-title">{title}</h5>
              <div className="d-flex justify-content-between align-items-center">
                <div className="btn-group">
                <Link to = {`/category/books/${id}`} className="btn btn-sm btn-outline-secondary">View</Link>
                </div>
                <small className="text-muted">{price} TL</small>
              </div>
            </div>
          </div>
        )
}

export default CategoryBookCard
