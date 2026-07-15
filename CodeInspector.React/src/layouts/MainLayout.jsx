import { Box } from "@mui/material";

import Sidebar from "../components/layout/Sidebar";
import Topbar from "../components/layout/Topbar";

export default function MainLayout({ children }) {

    return (

        <Box sx={{ display: "flex" }}>

            <Sidebar />

            <Topbar />

            <Box
                component="main"
                sx={{
                    flexGrow: 1,
                    p: 3,
                    mt: 8,
                    ml: "250px",
                    background: "#f4f6f8",
                    minHeight: "100vh"
                }}
            >
                {children}
            </Box>

        </Box>

    );

}