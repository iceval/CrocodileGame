import { FC } from 'react'
import { TopicProps } from "../../interfaces/topic.interface"

import TopicForm from '../TopicForm'

import './styles.scss'

export interface ModalProps {
    isShowTopicModal: boolean
    showTopicModal: () => void
    topic?: TopicProps
}

const TopicModal : FC<ModalProps> = ({ isShowTopicModal, showTopicModal, topic }) => {
    return (
        <>
            {isShowTopicModal && (
            <div className={`topicModal ${isShowTopicModal ? 'active' : ''}`}>
                <TopicForm showTopicModal={showTopicModal} topic={topic} />
            </div>
            )}
        </>
    )
}

export default TopicModal