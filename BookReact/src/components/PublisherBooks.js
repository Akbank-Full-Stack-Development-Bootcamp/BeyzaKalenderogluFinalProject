import React, {useState, useEffect} from 'react'
import PublisherBookCardList from "./PublisherBookCardList"

function PublisherBooks (props) {

    const [publisherBooks, setPublisherBooks] = useState([])
    const [loading, setLoading] = useState(false)

    useEffect(() => {

        const getPublisherBooks = () => {
            setLoading(true)
            fetch(`https://localhost:44318/api/publishers/${props.match.params.id}/books`)
              .then((response) => response.json())
              .then(json => {
                setPublisherBooks(json)
                setLoading(false)})
        }
        getPublisherBooks()
    },[props.match.params.id])
    return (
        <main>
        <div className="container">
          <div className="align-items-center">
          
          {loading ? (
          
              <div className="d-flex justify-content-center">
                <div className="spinner-border text-warning" role="status">
                  <span className="visually-hidden">Loading...</span>
                </div>
              </div>
            ) : (
              <PublisherBookCardList publisherBooks = {publisherBooks} />
              )}
          </div>
        </div>
      </main>
    )
}

export default PublisherBooks
