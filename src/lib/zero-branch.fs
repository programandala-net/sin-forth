\ lib/zero-branch.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require pop-hl.fs

get-order get-current

compiler-definitions

: 0branch \ Compilation: ( dest -- )
          \ Run-time:    ( f -- )
  assembler{
  pop-hl        \ pop hl
  l a ld,       \ ld a,l
  h or,         \ or h   ; HL = zero?
  $0000 z? ?jp, \ jp z,0 ; jump if zero, to an address which
                \        ; will be left by `>mark` and resolved
                \        ; by `>resolve` or `<resolve`.
  } ;

  \ doc{
  \
  \ 0branch  Compilation: ( dest -- )
  \          Run-time:    ( f -- )
  \ "zero-branch"

  \
  \ Compilation: Compile Z80 code to perform the run-time semantics
  \ below. The destination address _dest_ must be resolved by
  \ `>resolve` during the compilation.
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
