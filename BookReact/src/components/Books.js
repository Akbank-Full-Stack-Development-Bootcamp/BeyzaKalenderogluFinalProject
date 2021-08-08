
import React, { useState, useEffect } from 'react'
import Search from "./Search";
import CardList from "./CardList";

function Books() {

    const [books, setBooks] = useState([])
    const [loading, setLoading] = useState(false)
    

    useEffect(() => {
        getBooks()
    },[])

    const getBooks = () => {
        setLoading(true)
        fetch("https://localhost:44318/api/books")
          .then((response) => response.json())
          .then(json => {
              setBooks(json)
              setLoading(false)})
    }
    
     const searchBook = (term) => {
        fetch(`https://localhost:44318/api/books/search/${term}`)
        .then((response) => response.json())
        .then((data) => setBooks(data))
      }
    
        return (
            <main>
          <div className="container">
            <div className="align-items-center">
              <Search searchBook={searchBook}/>
              {loading ? (
                <div className="d-flex justify-content-center">
                  <div className="spinner-border text-warning" role="status">
                    <span className="visually-hidden">Loading...</span>
                  </div>
                </div>
              ) : (
                <CardList books={books} />
              )}
            </div>
          </div>
        </main>
        )
    }


export default Books

  





