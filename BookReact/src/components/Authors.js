
import React, { useState, useEffect } from 'react'
import SearchAuthor from "./SearchAuthor";
import AuthorCardList from "./AuthorCardList";

function Authors(){

    const [authors, setAuthors] = useState([])
    const [loading, setLoading] = useState(false)
    

    useEffect(() => {
        getAuthors()
    },[])

   

    const getAuthors = () => {
        setLoading(true)
        fetch("https://localhost:44318/api/authors")
          .then((response) => response.json())
          .then(json => {
              setAuthors(json)
              setLoading(false)
            })
    }

    const searchAuthor = (term) => {
        fetch(`https://localhost:44318/api/authors/search/${term}`)
        .then((response) => response.json())
        .then((data) => setAuthors(data))
      }

        return (
            <main>
          <div className="container">
            <div className="align-items-center">
            <SearchAuthor searchAuthor={searchAuthor}/>
              {loading ? (
                <div className="d-flex justify-content-center">
                  <div className="spinner-border text-warning" role="status">
                    <span className="visually-hidden">Loading...</span>
                  </div>
                </div>
              ) : (
                <AuthorCardList authors={authors} />
              )}
            </div>
          </div>
        </main>
        )
    }


export default Authors