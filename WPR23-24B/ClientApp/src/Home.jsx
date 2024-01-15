import { useEffect } from "react";
import HeroSection from "./components/WebsiteComponents/HeroSection";
import { useGlobalContext } from "./context";
import Contact from "./Contact";
import Services from "./Services";
import News from "./News";

const Home = () => {
  const { updateHomePage } = useGlobalContext();

  useEffect(() => updateHomePage(), []);

  return (
    <>
      <HeroSection />
      <Services />
      <Contact />
      <News/>
    </>
  );
};

export default Home;
