\ lib/question-branch.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require pop-hl.fs

get-order get-current

compiler-definitions

: ?branch \ Compilation: ( dest -- )
          \ Run-time:    ( f -- )
  assembler{
  pop-hl         \ pop hl
  l a ld,        \ ld a,l
  h or,          \ or h    ; HL = zero?
  $0000 nz? ?jp, \ jp nz,0 ; jump if zero, to an address which
                 \         ; will be left by `>mark` and resolved
                 \         ; by `>resolve` or `<resolve`.
  } ;

  \ doc{
  \
  \ ?branch  Compilation: ( dest -- )
  \          Run-time:    ( f -- )
  \ "question-branch"

  \
  \ Compilation: Compile Z80 code to perform the run-time semantics
  \ below. The destination address _dest_ must be resolved by
  \ `>resolve` during the compilation.
  \
  \ Run-time: If  _f_ is not false (zero), a Z80 ``jp`` is executed to
  \ an address that was resolved by `>resolve` during the compilation.

  \
  \ NOTE: This ``?branch`` is not Forth-83's ``?branch``, which is
  \ equivalent to fig-Forth's ``0branch``, which is a more logical
  \ name for the "branch if zero" action. Sin Forth borrows
  \ `0branch` from fig-Forth, and completes the branches after a
  \ logical naming convention shared with optional control flow
  \ words, e.g. `?exit`, `0exit`, `-exit`...

  \
  \ // XXX TODO
  \ // See also: `-branch`, `+branch`.
  \ See also: `branch`, `0branch`.
  \
  \ }doc

set-current set-order
