
import React, { useState, useEffect } from 'react'
import PublisherCardList from "./PublisherCardList";
import SearchPublisher from "./SearchPublisher"
function Publishers(){

    const [publishers, setPublishers] = useState([])
    const [loading, setLoading] = useState(false)
    

    useEffect(() => {
        getPublishers()
    },[])

   

    const getPublishers = () => {
        setLoading(true)
        fetch("https://localhost:44318/api/publishers")
          .then((response) => response.json())
          .then(json => {
              setPublishers(json)
              setLoading(false)
            })
    }
    const searchPublisher = (term) => {
        fetch(`https://localhost:44318/api/publishers/search/${term}`)
        .then((response) => response.json())
        .then((data) => setPublishers(data))
      }
        return (
            <main>
          <div className="container mt-5">
            <div className="align-items-center">
            <SearchPublisher searchPublisher={searchPublisher}/>
              {loading ? (
                <div className="d-flex justify-content-center">
                  <div className="spinner-border text-warning" role="status">
                    <span className="visually-hidden">Loading...</span>
                  </div>
                </div>
              ) : (
                <PublisherCardList publishers={publishers} />
              )}
            </div>
          </div>
        </main>
        )
    }


export default Publishers
