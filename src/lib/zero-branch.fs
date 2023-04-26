\ lib/zero-branch.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1122+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require pop-hl.fs

get-order get-current

compiler-definitions

: 0branch \ Compilation: ( -- )
          \ Run-time:    ( f -- )
  assembler{
  pop-hl        \ pop hl
  l a ld,       \ ld a,l
  h or,         \ or h   ; HL = zero?
  $0000 z? ?jp, \ jp z,0 ; jump if zero, to an address whose address
                \        ; will be left by `>mark` and resolved
                \        ; by `>resolve` or `<resolve`.
  } ;

  \ doc{
  \
  \ 0branch  Compilation: ( -- )
  \          Run-time:    ( f -- )
  \ "zero-branch"

  \
  \ Compilation: Compile Z80 code to perform the run-time semantics
  \ below. The destination address must be resolved by
  \ `>resolve` or `<resolve` during the compilation.
  \
  \ Run-time: If  _f_ is false (zero), a Z80 ``jp`` is executed to an
  \ address that was resolved by `>resolve` during the compilation.

  \
  \ // XXX TODO
  \ // See also: `-branch`, `+branch`.
  \
  \ See also: `branch`, `?branch`.
  \
  \ }doc

set-current set-order
