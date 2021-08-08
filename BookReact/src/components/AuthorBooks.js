import React, {useState, useEffect} from 'react'
import AuthorBookCardList from "./AuthorBookCardList"

function AuthorBooks (props) {

    const [authorBooks, setAuthorBooks] = useState([])
    const [loading, setLoading] = useState(false)

    useEffect(() => {

        const getAuthorBooks = () => {
            setLoading(true)
            fetch(`https://localhost:44318/api/authors/${props.match.params.id}/books`)
              .then((response) => response.json())
              .then(json => {
                setAuthorBooks(json.books)
                setLoading(false)})
        }
        getAuthorBooks()
    },[props.match.params.id])
    
    
    console.log(authorBooks)
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
              <AuthorBookCardList authorBooks = {authorBooks} />
              )}
          </div>
        </div>
      </main>
    )
}

export default AuthorBooks
