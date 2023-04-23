\ lib/u-m-slash-mod.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require here.fs      \ `here`
require pop-bc.fs    \ `pop-bc`
require pop-hl-de.fs \ `pop-hl-de`
require push-bc.fs   \ `push-bc`

get-order get-current

target-definitions

: um/mod ( ud u1 -- u2 u3 )

  assembler{

  exx,       \ exx
  pop-bc     \ call pop_bc            ; BC = divisor
  pop-hl-de  \ call pop_hl_de         ; HLDE = dividend
  #16 ld#,   \ ld a,16                ; loop counter
  e sla,     \ sla e
  d rl,      \ rl d                   ; hi bit DE -> Fc
             \ u_m_slash_mod.do:
  h adcp,    \ adc hl,hl              ; rot left with carry
  c? rif     \ jr nc,u_m_slash_mod.3
             \ ; case 1: 17 bit, Fc:HL = 1xxxx
    a or,    \ or a                   ; we know we can subtract
    b sbcp,  \ sbc hl,bc
    a or,    \ or a                   ; clear Fc to indicate sub ok
    \ compiler{ memory> } host{ @ } jr, >rmark 0 unresolved host{ @ ! }
    compiler{ t-here } jr, >rmark 0 unresolved host{ [.o] [.s] @ [.s] ! }
             \ jr u_m_slash_mod.4
             \ ; case 2: 16 bit, Fc:HL = $xxx
  rthen      \ u_m_slash_mod.3:
  b sbcp,    \ sbc hl,bc              ; try the subtract
  c? rif     \ jr nc,u_m_slash_mod.4  ; if no Fc, subtract ok
    b addp,  \ add hl,bc              ; else cancel the subtract
    scf,     \ scf                    ; and set Fc to indicate
  rthen      \ u_m_slash_mod.4:
  0 unresolved host{ @ } >rresolve
  rbegin
    e rl,    \ rl e                   ; rotate result bit into DE,
    d rl,    \ rl d                   ; and next bit of DE into Fc
    a dec,   \ dec a
  z? runtil  \ jr nz,u_m_slash_mod.do
             \ ; now have complemented quotient in DE,
             \ ; and remainder in HL
  d a ld,    \ ld a,d
  cpl,       \ cpl
  a b ld,    \ ld b,a
  e a ld,    \ ld a,e
  cpl,       \ cpl
  a c ld,    \ ld c,a
  push-hl    \ call push_hl           ; remainder
  push-bc    \ call push_bc           ; quotient
  exx,       \ exx

  }
  ;         \ ret

  \ Credit: Code adapted from Solo Forth, previously adapted from Z88
  \ CamelForth (Gary Lancaster, 2001).

  \ doc{
  \
  \ um/mod ( ud u1 -- u2 u3 ) "u-m-slash-mod"
  \
  \ Divide _ud_ by _u1_, giving the quotient _u3_ and the
  \ remainder _u2_.  All values and arithmetic are unsigned.
  \
  \ See also: `/mod`, `du/mod`, `mod`, `*/mod`.
  \
  \ }doc

set-current set-order
