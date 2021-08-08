import React, {useEffect, useState} from "react";
import {Link} from 'react-router-dom'

const Navbar = (props) =>  {

  const [categories, setCategories] = useState([])

  useEffect(() => {
      getCategories()
  },[])

  
  const getCategories = () => {
    fetch("https://localhost:44318/api/categories")
      .then((response) => response.json())
      .then(json =>  setCategories(json))
}

console.log(categories)
  
    return (
        <header>
        <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
        <div className="container">
          <Link className="navbar-brand d-flex align-items-center" to="/">BookContainer</Link>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNavDropdown">
            <ul className="navbar-nav">
              <li className="nav-item">
                <Link className="nav-link active" aria-current="page" to="/">Books</Link>
              </li>
              <li className="nav-item dropdown">
                <Link className="nav-link dropdown-toggle" to="/categories" id="navbarDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                  Categories
                </Link>
                <ul className="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">

                {
            categories.map(function(category){
            return(
              
                <li key={category.id}><Link className="dropdown-item"  to ={`/categories/${category.id}`}>{category.name}</Link></li>
               
            )
          })
        }
                  </ul> 
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/authors">Authors</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/publishers">Publishers</Link>
              </li>
              
            </ul>
          </div>
        </div>
      </nav>
      </header>
    );
  
}
export default Navbar;
