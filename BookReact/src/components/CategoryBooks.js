import React, {useEffect, useState} from "react";
import CategoryBookCardList from  "./CategoryBookCardList"
function CategoryBooks(props) {
    const[categoryBooks, setCategoryBooks] = useState([])
    const [loading, setLoading] = useState(false)

    
    console.log(categoryBooks)
    useEffect(() => {
    
       const getCategoryBooks = () => {
       fetch(`https://localhost:44318/api/categories/${props.match.params.id}/books`)
      .then((response) => response.json())
      .then(json => {
                setCategoryBooks(json.books)
                setLoading(false)})
    }
        getCategoryBooks()
    },[props.match.params.id])

    return (
        <div>
            <main>
        <div className="container mt-5">
          <div className="align-items-center">
          
          {loading ? (
          
              <div className="d-flex justify-content-center">
                <div className="spinner-border text-warning" role="status">
                  <span className="visually-hidden">Loading...</span>
                </div>
              </div>
            ) : (
              <CategoryBookCardList categoryBooks = {categoryBooks} />
              )}
          </div>
        </div>
      </main>
        </div>
    )
}

export default CategoryBooks
