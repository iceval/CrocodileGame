import { useEffect, useState } from 'react'
import { TopicProps } from '../../interfaces/topic.interface'
import { Link } from 'react-router-dom'

import TopicItem from '../../components/TopicItem'
import TopicModal from '../../components/TopicModal'

import './styles.scss'



export const Editor = () => {
  const [topics, setTopics] = useState<TopicProps[]>()
  const [topic, setTopic] = useState<TopicProps>()
  
  const [isShowTopicModal, setIsShowTopicModal] = useState<boolean>(false)

  useEffect(() => {
    fetchTopics()
  }, [])

  const showTopicModal = () => {
    setIsShowTopicModal((prev: boolean) => !prev)
  }

  const fetchTopics = async () => {
    await fetch(process.env.REACT_APP_API + 'topics')
      .then((resp: Response) => {
        return resp.json()
      })
      .then((data: TopicProps[]) => {
        setTopics(data)
      })
      .catch((e: Error) => {
        console.log(e.message)
      })
  }

  return (
    <div className="editor">
      <div className="editor__menu">
        <Link className="editor__button" to="/">Back</Link>
      </div>
      Editor
      <div className="editor__main">
        <TopicModal isShowTopicModal={isShowTopicModal} showTopicModal={showTopicModal} topic={topic} ></TopicModal>
        <div className="editor__topic-list">
          {
            topics?.map(topic => (
                <div key={topic.id} className="editor__topic-content">
                  <button onClick={() => {showTopicModal();setTopic(topic)}} className="editor__topic-button">
                    Edit Topic
                  </button>
                  <TopicItem topic={topic}/>
                </div>
            ))
          }
        </div>
      </div>
    </div>
  )
}