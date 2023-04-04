import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { Game } from '../pages/Game'
import { Editor } from '../pages/Editor'
import { TopicDetails } from '../pages/TopicDetails'
import { Menu } from '../pages/Menu'

import './styles.scss'

const App = () => {
  return (
    <div className="app">
      <BrowserRouter>
          <Routes>
              <Route path="/game" element={<Game />} />
              <Route path="/editor" element={<Editor />} />
              <Route path="/editor/topic/:topicId" element={<TopicDetails />}/>
              <Route path="/*" element={<Menu />} />
          </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App
