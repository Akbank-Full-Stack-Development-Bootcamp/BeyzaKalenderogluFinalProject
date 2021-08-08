import React, {  } from 'react'
import {Link} from "react-router-dom"

const  PublisherCard = (props) => {
    

      const{id, name} = props.publisher
        return (
            <main className="container">
                <div className="card  border-dark mb-3">
                <div className="card-columns ">
                <div className="card text-center">
                    <div className="card-body">
                    <h5 className="card-title mb-3">{name}</h5>
                    <Link to={`/publishers/${id}`}><button type="button" className="btn btn-sm btn-outline-secondary" data-toggle="button" aria-pressed="false" autocomplete="off">View Books</button></Link>
                </div>
                </div>  
                </div></div>
                {/* <div className="bg-light p-5 rounded">
                    <p className="display-6 text-center">{name}</p>
                    <Link to={`/publishers/${id}`}><button type="button" class="btn btn-primary" data-toggle="button" aria-pressed="false" autocomplete="off">View Books</button></Link>
                </div> */}
            </main>
        )

}
export default PublisherCard