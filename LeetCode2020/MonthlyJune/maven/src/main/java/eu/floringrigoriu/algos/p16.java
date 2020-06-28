package eu.floringrigoriu.algos;
// https://leetcode.com/explore/challenge/card/june-leetcoding-challenge/541/week-3-june-15th-june-21st/3362/
public class p16 {
    class Solution {
        public String validIPAddress(String IP) {
            if(IP.indexOf('.')>=0) {
                return isValidIPv4(IP) ? "IPv4" : "Neither";
            } else if(IP.indexOf(':')>=0) {
                return isValidIPv6(IP) ? "IPv6" : "Neither";
            }
            return "Neither";
        }
        
    

        public boolean isValidIPv4(String IP) {
            String[] segments = IP.split("\\.");
            if (segments.length!=4) {return false;}
            for(String segment: segments) {
                if(!isValidIPv4Segment(segment)) {return false;}
            }
            return true;
        }

        private boolean isValidIPv4Segment(String segment) {
            try{
                Integer value = Integer.parseInt(segment);
                return value >=0 && value <256 && segment.equals(value.toString());
            }catch(Exception e) {
                return false;
            }
        }

        public boolean isValidIPv6(String IP) {
            String[] segments = IP.split(":");
            if (segments.length!=8) {return false;}
            for(int i = 0; i< 8;i++) {
                if(!isValidIPv6Segment(segments[i], i==0)) {return false;}
            }
            return true;
        }

        private boolean isValidIPv6Segment(String segment, boolean isFirst) {
            if(isFirst) {
                if (segment.length()>4) {
                    return false;
                }
                if (segment.length()>1 && segment.charAt(0) == '0') {
                    return false;
                }
            }
            else if(!isFirst && segment.length()!=4) {return false;}

            for(char c : segment.toCharArray()) {
                c = Character.toLowerCase(c);
                if(!(c >= '0' && c<='9') || !(c >= 'a' && c<'g')) {
                    return false;
                }
            }
            return true;
        }
    }
    
}