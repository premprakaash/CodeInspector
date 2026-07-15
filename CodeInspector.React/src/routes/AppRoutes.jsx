import { Routes, Route } from "react-router-dom";

import Login from "../pages/Login";
import Dashboard from "../pages/Dashboard";
import Projects from "../pages/Projects";
import Reports from "../pages/Reports";
import Scan from "../pages/Scan";
import Settings from "../pages/Settings";

export default function AppRoutes() {
    return (
        <Routes>
            <Route path="/" element={<Login />} />
            <Route path="/dashboard" element={<Dashboard />} />
            <Route path="/projects" element={<Projects />} />
            <Route path="/reports" element={<Reports />} />
            <Route path="/scan" element={<Scan />} />
            <Route path="/settings" element={<Settings />} />
        </Routes>
    );
}